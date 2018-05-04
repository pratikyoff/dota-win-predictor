using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WinPredictor.Interfaces;
using WinPredictor.Algos;

namespace WinPredictor
{
    public class Predictor
    {
        public static int CurrentIteration { get; private set; }
        public static int TotalIterations { get; private set; }

        public async Task<double> Predict(List<int> inputToPredict, string steamId)
        {
            CurrentIteration = 0;
            TotalIterations = 0;

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
            throw new NotImplementedException();
        }

        private async Task<int[]> GetOutput(string steamId)
        {
            InOutBuilder inputBuilder = new InOutBuilder();
            var output = await inputBuilder.BuildOutput(steamId);
            //var outputArray = new int[output.Count * 2880];
            //for (int i = 0; i < output.Count; i++)
            //{
            //    for (int j = 0; j < 2880; j++)
            //    {
            //        outputArray[(i * 2880) + j] = output[i];
            //    }
            //}
            //return outputArray;
            return output.ToArray();
        }

        private async Task<double[][]> GetInput(string steamId)
        {
            InOutBuilder inputBuilder = new InOutBuilder();
            var input = await inputBuilder.BuildInput(steamId);

            var convertedInput = new double[input.Count][];

            for (int i = 0; i < input.Count; i++)
            {
                var permutation = new double[input[i].Count];
                for (int j = 0; j < input[i].Count; j++)
                {
                    permutation[j] = input[i][j];
                }
                convertedInput[i] = permutation;
            }

            return convertedInput;
        }
    }
}
