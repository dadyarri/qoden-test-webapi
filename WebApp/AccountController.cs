using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    [Authorize]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountCache _accountCache;

        public AccountController(IAccountService accountService, IAccountCache accountCache)
        {
            _accountService = accountService;
            _accountCache = accountCache;
        }

        [HttpGet]
        public ValueTask<Account> Get()
        {
            var extId = User.Claims.Single(claim => claim.Type == "ExternalId").Value;
            return _accountService.LoadOrCreateAsync(extId);
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public Account GetByInternalId([FromRoute] int id)
        {
            return _accountService.GetFromCache(id);
        }

        [HttpPost("counter")]
        public async Task UpdateAccount()
        {
            var account = await Get();
            account.Counter++;
            _accountCache.AddOrUpdate(account);
        }
    }
}