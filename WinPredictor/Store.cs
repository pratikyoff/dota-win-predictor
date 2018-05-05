using System;
using System.Collections.Generic;
using System.Text;

namespace WinPredictor
{
    public static class Store
    {
        public static Dictionary<string, dynamic> SteamIdToPlayerMatchInfo { get; private set; } = new Dictionary<string, dynamic>();
    }
}
