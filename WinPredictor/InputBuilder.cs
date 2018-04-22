﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WinPredictor
{
    public class InputBuilder
    {
        public async Task<List<List<int>>> Build(string steamId)
        {
            var input = new List<List<int>>();

            var basicMatchDetailsArray = await MatchAPI.GetBasicInfoOfAllMatchesOfPlayer(steamId);
            List<string> matchIds = new List<string>();
            foreach (var match in basicMatchDetailsArray)
            {
                string matchId = (string)match.match_id;
                matchIds.Add(matchId);
            }

            foreach (var matchId in matchIds)
            {
                bool retry = true;
                int counter = 0;
                while (retry)
                {
                    try
                    {
                        await GetInputs(steamId, input, matchId);
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
            }
            return input;
        }

        private static async Task GetInputs(string steamId, List<List<int>> input, string matchId)
        {
            var matchDetails = await MatchAPI.GetMatchDetails(matchId);
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
            var allyPermutations = Permutator.Permute(allyHeroIds);
            var enemyPermutations = Permutator.Permute(enemyHeroIds);
            foreach (var allyPermutation in allyPermutations)
            {
                foreach (var enemyPermutation in enemyPermutations)
                {
                    var oneCompletePermutation = new List<int>() { ownHeroId };
                    oneCompletePermutation.AddRange(allyPermutation);
                    oneCompletePermutation.AddRange(enemyPermutation);
                    oneCompletePermutation.Add(radiantOrDire);
                    input.Add(oneCompletePermutation);
                }
            }
        }
    }
}