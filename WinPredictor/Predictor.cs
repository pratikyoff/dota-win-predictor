using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WinPredictor.Interfaces;
using WinPredictor.Algos;
using System.Threading;

namespace WinPredictor
{
    public class Predictor
    {
        public int CurrentIteration { get; private set; }

        public double Predict(List<int> inputToPredict, string steamId)
        {
            IAlgorithm mlAlgorithm;
            if (MLEngineStore.Store.ContainsKey(steamId))
            {
                mlAlgorithm = MLEngineStore.Store[steamId];
            }
            else
            {
                mlAlgorithm = new SMOAlgo();
                MLEngineStore.Store.Add(steamId, mlAlgorithm);

                foreach (var learnCase in GetLearnCases(steamId))
                {
                    mlAlgorithm.Learn(learnCase.Input, learnCase.Output);
                    CurrentIteration++;
                }
            }

            var result = mlAlgorithm.CalculteOutput(inputToPredict);

            return result;
        }

        private IEnumerable<LearnCase> GetLearnCases(string steamId)
        {
            var basicMatchDetailsArray = MatchAPI.GetBasicInfoOfAllMatchesOfPlayer(steamId).GetAwaiter().GetResult();

            foreach (var match in basicMatchDetailsArray)
            {
                string matchId = (string)match.match_id;
                dynamic matchDetails = null;

                #region Getting match details
                bool retry = true;
                int counter = 0;
                while (retry)
                {
                    try
                    {
                        matchDetails = MatchAPI.GetMatchDetails(matchId).GetAwaiter().GetResult();
                        retry = false;
                    }
                    catch (Exception exception)
                    {
                        counter++;
                        retry = true;
                        if (counter > 10)
                            throw exception;
                        Thread.Sleep(counter * 1000);
                    }
                }
                #endregion

                List<int> inputToPermute = new List<int>();

                #region input list calculation
                //Calculating the input list
                int ownHeroId = 0;
                List<int> allyHeroIds = new List<int>();
                List<int> enemyHeroIds = new List<int>();
                bool isRadiant = false;
                int radiantOrDire = 0;
                foreach (var playerInfo in matchDetails.players)
                {
                    if ((string)playerInfo.account_id == steamId)
                    {
                        ownHeroId = playerInfo.hero_id;
                        isRadiant = playerInfo.isRadiant;
                        radiantOrDire = isRadiant ? 0 : 1;
                        break;
                    }
                }
                foreach (var playerInfo in matchDetails.players)
                {
                    if ((string)playerInfo.account_id != steamId)
                    {
                        if (playerInfo.isRadiant == isRadiant)
                        {
                            allyHeroIds.Add((int)playerInfo.hero_id);
                        }
                        else
                        {
                            enemyHeroIds.Add((int)playerInfo.hero_id);
                        }
                    }
                }
                inputToPermute.Add(ownHeroId);
                inputToPermute.AddRange(allyHeroIds);
                inputToPermute.AddRange(enemyHeroIds);
                inputToPermute.Add(radiantOrDire);
                #endregion

                #region output calculation
                int win = isRadiant == (bool)matchDetails.radiant_win ? 1 : 0;
                #endregion

                var permutations = Permutator.PermuteMatch(inputToPermute);

                foreach (var permutation in permutations)
                {
                    LearnCase learnCase = new LearnCase()
                    {
                        Input = permutation.ToArray(),
                        Output = win
                    };
                    yield return learnCase;
                }
            }
        }
    }
}
