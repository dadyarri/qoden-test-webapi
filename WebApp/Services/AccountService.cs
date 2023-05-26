using System.Threading.Tasks;
using WebApp.Data.Cache;
using WebApp.Data.Models;

namespace WebApp.Services
{
    class AccountService : IAccountService
    {
        private readonly IAccountCache _cache;
        private readonly IAccountDatabase _db;

        public AccountService(IAccountCache cache, IAccountDatabase db)
        {
            _cache = cache;
            _db = db;
        }

        public Account GetFromCache(long id)
        {
            if (_cache.TryGetValue(id, out var account))
            {
                return account;
            }

            return null;
        }

        public async ValueTask<Account> GetFromCacheOrLoad(long id)
        {
            
            var account = GetFromCache(id) ?? await _db.GetAccountOrNullAsync(id);
            if (account != null)
            {
                _cache.AddOrUpdate(account);
            }
            return account;
        }

        public async ValueTask<Account> LoadOrCreateAsync(string id)
        {
            if (!_cache.TryGetValue(id, out var account))
            {
                account = await _db.GetOrCreateAccountAsync(id);
                _cache.AddOrUpdate(account);
            }

            return account;
        }

        public async ValueTask<Account> LoadOrCreateAsync(long id)
        {
            if (!_cache.TryGetValue(id, out var account))
            {
                account = await _db.GetOrCreateAccountAsync(id);
                _cache.AddOrUpdate(account);
            }

            return account;
        }
    }
}