using BookStoreAPI.Models.DTO;
using BookStoreAPI.Repositories;
using BookStoreAPI.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<AuthController> _logger;

        public AuthController(TokenService tokenService, IAuthRepository authRepository, ILogger<AuthController> logger)
        {
            _tokenService = tokenService;
            _authRepository = authRepository;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            // Validate user credentials using the repository
            var isValidUser = await _authRepository.ValidateUserCredentialsAsync(loginDTO.Username, loginDTO.Password);

            if (isValidUser)
            {
                var user = await _authRepository.GetUserByUsernameAsync(loginDTO.Username);

                // Generate token
                var token = _tokenService.GenerateToken(user.Id, user.Username, user.Role);

                // Return both the token and the username
                return Ok(new
                {
                    Username = user.Username,
                    Token = token
                });
            }

            return Unauthorized();
        }
    }
}
