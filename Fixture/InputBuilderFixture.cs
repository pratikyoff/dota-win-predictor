using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WinPredictor;
using Xunit;

namespace Fixture
{
    public class InputBuilderFixture
    {
        [Fact]
        public async void BuildFixture()
        {
            InOutBuilder inputBuilder = new InOutBuilder();
            var a = await inputBuilder.BuildInput("190500077");
            Assert.NotNull(a);
        }
    }
}
