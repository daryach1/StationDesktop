using StationDesktop.Services;
using Xunit;

namespace StationDesktop.Tests
{
    public class ContextTests
    {
        [Fact]
        public void CheckUserTrueDataTest()
        {
            StationContext context = new StationContext();
            string login = "cherc";
            string password = "1344";

            var user = UserService.CheckUser(login, password, context);

            Assert.True(user);
        }

        [Fact]
        public void CheckUserFalseDataTest()
        {
            StationContext context = new StationContext();
            string login = "wag";
            string password = "2566";

            var user = UserService.CheckUser(login, password, context);

            Assert.False(user);
        }
    }
}