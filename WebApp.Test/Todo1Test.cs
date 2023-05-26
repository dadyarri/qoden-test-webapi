using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Net.Http.Headers;
using NUnit.Framework;

namespace WebApp.Test
{
    public class Todo1Test: MyTestBase
    {
        [Test(Description = "TODO 1: Sign in should generate auth cookie")]
        public async Task SignInShouldGenerateAuthCookie()
        {
            // Act
            var response = await AliceClient.SignInAsync("alice@mailinator.com");
            var cookieHeaderFound = response.Headers.TryGetValues(HeaderNames.SetCookie, out var cookies);
            
            // Assert
            cookieHeaderFound.Should().BeTrue();
            cookies.Should().NotBeEmpty();
        }
    }
}