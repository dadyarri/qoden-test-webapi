using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace WebApp.Test
{
    public class Todo5Test: MyTestBase
    {
        [Test(Description = "TODO5: Endpoint /api/account/{id} should work with user with admin role")]
        public async Task GetAccountByInternalId__ShouldWork__WhenUserHaveAdminRole()
        {
            // Act
            var response = await AliceClient.GetAccountByIdAsync(1);
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Test(Description = "TODO5: Endpoint /api/account/{id} shouldn't work with user without admin role")]
        public async Task GetAccountByInternalId__ShouldNotWork__WhenUserDoesNotHaveAdminRole()
        {
            // Act
            var response = await BobClient.GetAccountByIdAsync(1);
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}