using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;

namespace WinPredictor
{
    public class Predictor
    {
        public async Task<double> Predict(List<int> inputToPredict, string steamId)
        {
            var input = await GetInput(steamId);
            var output = await GetOutput(steamId);

            var teacher = new SequentialMinimalOptimization<Gaussian>()
            {
                UseComplexityHeuristic = true,
                UseKernelEstimation = true
            };

            var svm = teacher.Learn(input, output);

            double[] convertedInputToPredict = ConvertToDoubleArray(inputToPredict);

            var result = svm.Probability(convertedInputToPredict);

            return result;
        }

        private double[] ConvertToDoubleArray(List<int> list)
        {
            var array = new double[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i];
            }
            return array;
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
