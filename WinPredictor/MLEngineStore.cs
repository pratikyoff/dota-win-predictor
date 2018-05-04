using Accord.MachineLearning.VectorMachines;
using Accord.Statistics.Kernels;
using System.Collections.Generic;
using WinPredictor.Interfaces;

namespace WinPredictor
{
    public static class MLEngineStore
    {
        public static Dictionary<string, IAlgorithm> Store { get; set; } = new Dictionary<string, IAlgorithm>();
    }
}
