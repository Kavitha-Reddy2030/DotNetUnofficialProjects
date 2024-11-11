using BookStoreAPI.Models.Domain;
using System.Threading.Tasks;

namespace BookStoreAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> ValidateUserCredentialsAsync(string username, string password);
    }
}
