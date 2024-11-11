using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace Minimal_ASP.NET_Web_API_with_JWT_Authentication
{
    public class JwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        // Generate JWT token
        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),  // Set expiration time for the token
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // Validate the JWT token
        // public bool ValidateToken(string token, out string username)
        // {
        //     username = "w";
        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        //
        //     try
        //     {
        //         var validationParameters = new TokenValidationParameters
        //         {
        //             ValidateIssuerSigningKey = true,
        //             IssuerSigningKey = new SymmetricSecurityKey(key),
        //             ValidateIssuer = true,
        //             ValidIssuer = _jwtSettings.Issuer,
        //             ValidateAudience = true,
        //             ValidAudience = _jwtSettings.Audience,
        //             ValidateLifetime = true,
        //             ClockSkew = TimeSpan.Zero  // No clock skew tolerance
        //         };
        //
        //         var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
        //
        //         if (validatedToken is JwtSecurityToken jwtToken)
        //         {
        //             username = principal.Identity?.Name;
        //             return true;
        //         }
        //     }
        //     catch (SecurityTokenExpiredException)
        //     {
        //         // Token has expired
        //     }
        //     catch (Exception)
        //     {
        //         // Other exceptions can be logged
        //     }
        //
        //     return false;
        // }
    }
}
