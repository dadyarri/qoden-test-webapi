using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WebApp.Data.Models;

namespace WebApp.Test
{
    public class Todo3Test: MyTestBase
    {
        [Test(Description = "/api/account should return correct current user info based on auth info")]
        public async Task GetAccount__ShouldReturnCorrectUserInfo__Alice()
        {
            // Act
            var response = await AliceClient.GetAccountAsync();
            var data = JsonSerializer.Deserialize<Account>(await response.Content.ReadAsStringAsync());
            
            // Assert
            data.ExternalId.Should().Be("alice");
        }
        
        [Test(Description = "/api/account should return correct current user info based on auth info")]
        public async Task GetAccount__ShouldReturnCorrectUserInfo__Bob()
        {
            // Act
            var response = await BobClient.GetAccountAsync();
            var data = JsonSerializer.Deserialize<Account>(await response.Content.ReadAsStringAsync());
            
            // Assert
            data.ExternalId.Should().Be("bob");
        }
    }
}