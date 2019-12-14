using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TwinCityCoders.Utilities.Hashing
{
    public static class JWTToken
    {
        public static string GenerateToken(string RoleId,string PersonId, string Username, string UserId, string SecretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, RoleId),
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.NameIdentifier,PersonId),
                    new Claim(ClaimTypes.GroupSid,UserId),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
