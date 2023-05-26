using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace WebApp.Test
{
    public class Todo2Test : MyTestBase
    {
        [Test(Description = "TODO 2: Attempt to login as non-existent user should response with 404")]
        public async Task AttemptToLoginAsNonExistentUser__ShouldResponseAs404()
        {
            // Act
            var response = await AliceClient.SignInAsync("userthatdoesnotexist@mailinator.com");
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}