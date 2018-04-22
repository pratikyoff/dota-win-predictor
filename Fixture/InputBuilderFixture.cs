using System;
using System.Collections.Generic;
using System.Text;
using WinPredictor;
using Xunit;

namespace Fixture
{
    public class InputBuilderFixture
    {
        [Fact]
        public async void BuildFixture()
        {
            InputBuilder inputBuilder = new InputBuilder();
            var a = await inputBuilder.Build("190500077");
            Assert.NotNull(a);
        }
    }
}
