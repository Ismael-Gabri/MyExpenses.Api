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
            var tokenHandler = new JwtSecurityTokenHandler(); //Token Handler
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); //Codificar a key para array de bytes para o Handler
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.Name, user.Name),
                    new ("Email", user.Email),
                    new (ClaimTypes.Role, "user")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //Criar configurações do token

            var token = tokenHandler.CreateToken(tokenDescriptor); //Criar token baseado no token description
            return tokenHandler.WriteToken(token); //Retornar token em formato string
        }
    }
}
