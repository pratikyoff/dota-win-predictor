using WinPredictor;
using Xunit;

namespace Fixture
{
    public class MatchAPIFixture
    {
        [Fact]
        public async void PlayerBasicMatchGetterFixture()
        {
            var response = await MatchAPI.GetBasicInfoOfAllMatchesOfPlayer("190500077");
            Assert.NotNull(response);
        }

        [Fact]
        public async void MatchGetterFixture()
        {
            var response = await MatchAPI.GetMatchDetails("3842414268");
            Assert.NotNull(response);
        }
    }
}
