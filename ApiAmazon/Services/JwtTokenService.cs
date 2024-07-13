using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAmazon.Services
{
    public class JwtTokenService : IJwtTokenGenerator
    {
        private readonly JWTOptions options;
        public JwtTokenService(IOptions<JWTOptions> _options)
        {
            options = _options.Value;
        }
        public string TokenGenerator(ApplicationUser applicationUser, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options.Secret);
            var claims = new List<Claim>()
            {
                new Claim (JwtRegisteredClaimNames.Sub, applicationUser.Id),
                new Claim (JwtRegisteredClaimNames.GivenName,applicationUser.FirstName),
                new Claim (JwtRegisteredClaimNames.Email,applicationUser.Email),
            };
            claims.AddRange(roles.Select(roles => new Claim(ClaimTypes.Role, roles)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = options.Audience,
                Issuer = options.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
