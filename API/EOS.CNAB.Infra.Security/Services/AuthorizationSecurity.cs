using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Security;
using EOS.CNAB.Infra.Security.Settings;
using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EOS.CNAB.Infra.Security.Services
{
    public class AuthorizationSecurity : IAuthorizationSecurity
    {
        private readonly JwtSettings _jwtSettings;

        public AuthorizationSecurity(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string CreateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //gravar os dados do usuário no token
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, usuario.Nome), //identificação do usuário autenticado
                    new Claim(ClaimTypes.Email, usuario.Email), //perfil do usuário autenticado
                    
                }),

                //definindo a data e hora de expiração
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationInHours),

                //criptografar a chave antifalsificação no token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            //retornando o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
