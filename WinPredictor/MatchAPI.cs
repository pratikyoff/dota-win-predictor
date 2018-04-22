using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WinPredictor
{
    public static class MatchAPI
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async static Task<dynamic> GetBasicInfoOfAllMatchesOfPlayer(string steamId)
        {
            var response = await httpClient.GetStringAsync($"https://api.opendota.com/api/players/{steamId}/matches");
            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json;
        }

        public async static Task<dynamic> GetMatchDetails(string matchId)
        {
            LocalMatchStore localMatchStore = new LocalMatchStore();
            if (localMatchStore.CheckIfPresent(matchId))
                return localMatchStore.GetMatchDetails(matchId);

            var response = await httpClient.GetStringAsync($"https://api.opendota.com/api/matches/{matchId}");
            var json = JsonConvert.DeserializeObject<dynamic>(response);
            localMatchStore.StoreMatch(json);
            return json;
        }
    }
}
