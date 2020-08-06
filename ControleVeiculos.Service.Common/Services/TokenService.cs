using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Service.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleVeiculos.Service.Common.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfigurationManagerService settingsService;

        public TokenService(IConfigurationManagerService settingsService)
        {
            this.settingsService = settingsService;
        }

        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settingsService.GetSecurityKey());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = settingsService.GetSetting("AudienceKey"),
                Issuer = settingsService.GetSetting("IssuerKey"),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email.ToString()),
                    new Claim(ClaimTypes.Name, usuario.NomeCompleto.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
