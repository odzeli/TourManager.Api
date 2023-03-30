using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using TourManager.Auth.API.Models;
using TourManager.Auth.API.Storage;
using TourManager.Auth.Common;

namespace TourManager.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Accounts accounts;
        private readonly IOptions<AuthOptions> authOptions;
        public AuthController(Accounts accounts, IOptions<AuthOptions> authOptions)
        {
            this.accounts = accounts;
            this.authOptions = authOptions;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);
            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(token);
            }
            return Unauthorized();
        }

        private Account AuthenticateUser(string email, string password)
        {
            return accounts.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        private Token GenerateJWT(Account user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            };

            foreach(var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }
            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            var currentToken = new Token();
            currentToken.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return currentToken;
        }
    }
}
