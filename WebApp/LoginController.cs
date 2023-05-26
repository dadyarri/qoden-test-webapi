using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    [Route("api")]
    public class LoginController : Controller
    {
        private readonly IAccountDatabase _db;

        public LoginController(IAccountDatabase db)
        {
            _db = db;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login(string userName)
        {
            var account = await _db.FindByUserNameAsync(userName);
            if (account != null)
            {
                Response.Cookies.Append("ExternalId", account.ExternalId);
                return Ok();
            }
            return NotFound();
        }
    }
}