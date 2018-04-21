using System;
using System.Collections.Generic;
using WinPredictor;
using Xunit;

namespace Fixture
{
    public class PermutatorFixture
    {
        [Fact]
        public void CheckingPermutation()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var result = Permutator.Permute(list);
            Assert.True(result.Count == 120);
        }
    }
}
