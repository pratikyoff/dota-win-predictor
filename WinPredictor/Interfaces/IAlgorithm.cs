using System.Collections.Generic;

namespace WinPredictor.Interfaces
{
    public interface IAlgorithm
    {
        //Learn should be able to be called multiple times
        void Learn(IEnumerable<int> input, int output);
        double CalculteOutput(IEnumerable<int> input);
    }
}
