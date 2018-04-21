using Host.Models;
using System.Collections.Generic;
using WinPredictor;

namespace Host.Services
{
    public class WinPredictorService
    {
        public double GetResult(PredictionRequest predictionRequest)
        {
            var input = new List<int>() { predictionRequest.OwnHeroId };
            input.AddRange(predictionRequest.AllyHeroIds);
            input.AddRange(predictionRequest.EnemyHeroIds);
            input.Add(predictionRequest.IsRadiant ? 0 : 1);

            Predictor predictor = new Predictor();

            return predictor.Predict(input, predictionRequest.SteamId).GetAwaiter().GetResult();
        }
    }
}
