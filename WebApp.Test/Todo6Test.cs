using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using WebApp.Data.Models;

namespace WebApp.Test
{
    public class Todo6Test : MyTestBase
    {
        [Test(Description = "TODO 6: Counter of user should be updated correctly"), Order(1)]
        [Repeat(30)]
        public async Task CounterOfUserShouldBeUpdatedCorrectly()
        {
            var tasks = new List<Task>();
            for (var i = 0; i < 200; i++)
            {
                tasks.Add(new Task(async () => await AliceClient.GetAccountAsync()));
            }

            tasks.AsParallel().ForAll(x => x.Start());
            await Task.WhenAll(tasks);
            await AliceClient.CountAsync();
            await AliceClient.CountAsync();
            await AliceClient.CountAsync();
            await AliceClient.CountAsync();
            await AliceClient.CountAsync();
            var account = await (await AliceClient.GetAccountByIdAsync(1)).Response<Account>();
            if (account.Counter != 5)
                throw new Exception($"counter is {account.Counter}");
        }
    }
}
