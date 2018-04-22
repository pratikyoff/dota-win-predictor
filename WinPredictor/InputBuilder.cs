using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinPredictor
{
    public class InputBuilder
    {
        public async Task<List<List<int>>> Build(string steamId)
        {
            var basicMatchDetailsArray = await MatchAPI.GetBasicInfoOfAllMatchesOfPlayer(steamId);
            List<string> matchIds = new List<string>();
            foreach (var match in basicMatchDetailsArray)
            {
                string matchId = (string)match.match_id;
                matchIds.Add(matchId);
            }

            int ownHeroId;
            int[] allyHeroIds = new int[4];
            int[] enemyHeroIds = new int[5];
            int radiantOrDire;

            var tasks = new List<Task>();
            foreach (var matchId in matchIds)
            {
                var task = Task.Run(async () =>
                {

                });
                tasks.Add(task);
            }

            return null;
        }
    }
}