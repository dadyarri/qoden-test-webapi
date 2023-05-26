using System.Threading.Tasks;

namespace WebApp
{
    public interface IAccountDatabase
    {
        Task<Account> GetAccountOrNullAsync(long id);
        Task<Account> GetOrCreateAccountAsync(string id);

        Task<Account> GetOrCreateAccountAsync(long id);

        Task<Account> FindByUserNameAsync(string userName);

        Task ResetAsync();
    }
}