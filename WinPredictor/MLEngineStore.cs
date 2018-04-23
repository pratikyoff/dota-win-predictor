using Accord.MachineLearning.VectorMachines;
using Accord.Statistics.Kernels;
using System.Collections.Generic;

namespace WinPredictor
{
    public static class MLEngineStore
    {
        public static Dictionary<string, SupportVectorMachine<Gaussian>> Store { get; set; } = new Dictionary<string, SupportVectorMachine<Gaussian>>();
    }
}
