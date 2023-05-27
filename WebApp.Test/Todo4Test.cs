using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace WebApp.Test
{
    public class Todo4Test: MyTestBase
    {
        [Test(Description = "TODO4: Unauthorized users should get 401 response on requests to /api/account")]
        public async Task UnauthorizedUsers__ShouldGet401Response__WhenAccountRouteRequested()
        {
            // Act
            var response = await Client.GetAccountAsync();
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}