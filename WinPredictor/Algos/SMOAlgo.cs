using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using System;
using System.Collections.Generic;
using System.Linq;
using WinPredictor.Interfaces;

namespace WinPredictor.Algos
{
    public class SMOAlgo : IAlgorithm
    {
        private SequentialMinimalOptimization<Gaussian> _teacher;
        private SupportVectorMachine<Gaussian> _supportVectorMachine;

        public SMOAlgo()
        {
            _teacher = new SequentialMinimalOptimization<Gaussian>()
            {
                UseComplexityHeuristic = true,
                UseKernelEstimation = true
            };
        }

        public double CalculteOutput(IEnumerable<int> input)
        {
            return _supportVectorMachine.Probability(GetDoubleArray(input));
        }

        public void Learn(IEnumerable<int> input, int output)
        {
            var inputForLearning = new double[][] { GetDoubleArray(input) };
            _supportVectorMachine = _teacher.Learn(inputForLearning, new int[] { output });
        }

        private double[] GetDoubleArray(IEnumerable<int> input)
        {
            var toReturn = new double[input.Count()];
            int i = 0;
            foreach (var a in input)
            {
                toReturn[i++] = a;
            }
            return toReturn;
        }
    }
}
