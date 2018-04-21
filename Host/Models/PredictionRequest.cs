using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host.Models
{
    public class PredictionRequest
    {
        public int OwnHeroId { get; set; }
        public List<int> AllyHeroIds { get; set; } = new List<int>();
        public List<int> EnemyHeroIds { get; set; } = new List<int>();
        public bool IsRadiant { get; set; }
        public string SteamId { get; set; }
    }
}
