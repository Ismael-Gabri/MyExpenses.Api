using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Queries;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Services
{
    public class TokenService
    {
        public string GenerateToken(GetUserByEmailQueryResult user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new ("Id", user.Id.ToString()),
                    new (ClaimTypes.Name, user.Name),
                    new ("Email", user.Email),
                    new (ClaimTypes.Role, "user")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateAdminToken(GetUserByEmailQueryResult user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new ("Id", user.Id.ToString()),
                    new (ClaimTypes.Name, user.Name),
                    new ("Email", user.Email),
                    new (ClaimTypes.Role, "admin"),
                    new (ClaimTypes.Role, "user")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
