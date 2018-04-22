using System;
using System.Collections.Generic;
using System.Text;
using WinPredictor;
using Xunit;

namespace Fixture
{
    public class PredictorFixture
    {
        [Fact]
        public async void TestingPrediction()
        {
            Predictor predictor = new Predictor();
            var input = new List<int>() { 23, 30, 32, 33, 34, 35, 36, 37, 38, 39, 0 };
            var winChance = await predictor.Predict(input, "190500077");
            Assert.True(winChance >= 0 && winChance <= 1);
        }
    }
}
