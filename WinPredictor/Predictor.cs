using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinPredictor
{
    public class Predictor
    {
        public async Task<double> Predict(List<int> input, string steamId)
        {
            return 0.5;
        }

        private async Task<List<List<int>>> GetLearningConditions(string steamId)
        {
            InputBuilder inputBuilder = new InputBuilder();
            var input = await inputBuilder.Build(steamId);
            return input;
        }
    }
}
