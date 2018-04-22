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
            InputBuilder inputBuilder = new InputBuilder();
            var a = await inputBuilder.Build("343123158");
            Assert.NotNull(a);
        }
    }
}
