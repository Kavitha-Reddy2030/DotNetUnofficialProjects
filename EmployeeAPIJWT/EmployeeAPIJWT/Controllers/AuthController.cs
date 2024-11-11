using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPIJWT.Models.DTO;
using EmployeeAPIJWT.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            // Validate user credentials (this is just an example, replace with actual validation logic)
            if (loginDTO.Username == "user1" && loginDTO.Password == "user123")
            {
                // Generate token
                var token = _tokenService.GenerateToken(Guid.NewGuid(), loginDTO.Username);

                // Return both the token and the username
                return Ok(new
                {
                    Username = loginDTO.Username,
                    Token = token
                });
            }

            return Unauthorized();
        }
    }
}
