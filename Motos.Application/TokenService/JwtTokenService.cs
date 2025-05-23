using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Motos.Domain.Services;
using Motos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.TokenService
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public JwtTokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // Implementação do método da interface, agora com 'roles' e 'additionalClaims'
       public async Task<string> GenerateToken(ApplicationUser user, IList<string> roles, IList<Claim> additionalClaims = null) 
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var secretKey = jwtSettings["Secret"];
            var issuer = jwtSettings["Issuer"];
            var expiresInMinutes = int.Parse(jwtSettings["ExpiresInMinutes"] ?? "60");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("FullName", user.FullName),
             
              
                // new Claim("fullname", user.FullName ?? ""),
                // new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            // ADICIONANDO AS ROLES COMO CLAIMS
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // ADICIONANDO CLAIMS PERSONALIZADOS
            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims );
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiresInMinutes),
                Issuer = issuer,
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return  tokenHandler.WriteToken(token);
        }


    }
}
