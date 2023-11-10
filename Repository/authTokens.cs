using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NgGold.Models;


namespace NgGold.Auth.Token
{

    public class AccessToken
    {

        private readonly IConfiguration _configuration;

        public AccessToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string BearerToken(string secretKey, Users users)
        {
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, ""),
            new Claim(JwtRegisteredClaimNames.Email, "kelvinmansi2@gmail.com"),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtOptions:Issuer"],
                audience: _configuration["JwtOptions:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(2000),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}

