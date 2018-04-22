using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WinPredictor
{
    public class LocalMatchStore
    {
        private string _directory = "D:\\data\\Match Details";

        public LocalMatchStore()
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);
        }

        public bool CheckIfPresent(string matchId)
        {
            return File.Exists(Path.Combine(_directory, $"{matchId}.json"));
        }

        public bool StoreMatch(dynamic matchDetails)
        {
            string matchDetailsJson = JsonConvert.SerializeObject(matchDetails);
            File.WriteAllText(Path.Combine(_directory, $"{matchDetails.match_id}.json"), matchDetailsJson);
            return true;
        }

        public dynamic GetMatchDetails(string matchId)
        {
            if (CheckIfPresent(matchId) == false)
                return null;
            string fileContents = File.ReadAllText(Path.Combine(_directory, $"{matchId}.json"));
            return JsonConvert.DeserializeObject<dynamic>(fileContents);
        }
    }
}
