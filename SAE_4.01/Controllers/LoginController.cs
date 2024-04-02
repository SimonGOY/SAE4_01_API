using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly IDataRepository<User> dataRepository;

        public LoginController(IConfiguration config, IDataRepository<User> dataRepository)
        {
            _config = config;
            this.dataRepository = dataRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            IActionResult response = Unauthorized();
            User user = await AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJwtToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }

        private async Task<User> AuthenticateUser(LoginRequest user)
        {
            var usersResult = await dataRepository.GetAllAsync();

            var users = usersResult.Value as IEnumerable<User>;

            return users.SingleOrDefault(x => x.Email.ToUpper() == user.Email.ToUpper() && x.Password == user.Password);
        }

        private string GenerateJwtToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim("role", userInfo.TypeCompte.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                 issuer: _config["Jwt:Issuer"],
                 audience: _config["Jwt:Audience"],
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(30),
                 signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [HttpGet("Profile")]
        public async Task<User> GetUserProfileAsync()
        {
            // Get JWT token from request headers
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Validate and extract user identity
            string userId = GetUserIdFromToken(token);

            // Retrieve user profile from database using the userId

            var usersResult = await dataRepository.GetAllAsync();

            var users = usersResult.Value as IEnumerable<User>;

            return users.SingleOrDefault(x => x.Email.ToUpper() == userId.ToUpper());
        }

        private string GetUserIdFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            // Example: extracting user ID from 'sub' claim
            var userId = token.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value;

            return userId;
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
