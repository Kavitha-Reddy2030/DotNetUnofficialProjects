using BookStoreAPI.Data;
using BookStoreAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStoreAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public AuthRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Implement the interface method to get a user by username
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        // Implement the interface method to validate user credentials
        public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            var user = await GetUserByUsernameAsync(username);
            return user != null && user.PasswordHash == password;
        }
    }
}
