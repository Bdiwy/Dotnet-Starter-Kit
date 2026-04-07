using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Auth
{
    public class JwtTokenGenerator(IConfiguration _config) : IJwtTokenGenerator
    {
        /// <summary>
        /// Generates a JWT token for the given user and their permissions
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public string GenerateToken(User user, IEnumerable<string> permissions)
        {
            var claims = CreateClaims(user, permissions);
            var signingCredentials = CreateSigningCredentials();
            var tokenDescriptor = CreateTokenDescriptor(claims, signingCredentials);

            return GenerateJwtToken(tokenDescriptor);
        }

        /// <summary>
        /// Creates all claims for the JWT token
        /// </summary>
        private List<Claim> CreateClaims(User user, IEnumerable<string> permissions)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("tenantId", user.TenantId.ToString()),
                new Claim("teamId", user.TeamId?.ToString() ?? ""),
                new Claim("isOwner", user.IsOwner.ToString()),
                new Claim("role", user.Role.Name)
            };
            
            if(!user.IsOwner)
            {
                foreach (var permission in permissions)
                {
                    claims.Add(new Claim("permission", permission));
                }
            }

            return claims;
        }

        /// <summary>
        /// Creates the signing credentials using the secret key from configuration
        /// </summary>
        private SigningCredentials CreateSigningCredentials()
        {
            var secretKey = _config["JwtSettings:Secret"] 
                ?? throw new InvalidOperationException("JWT Secret is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Builds the SecurityTokenDescriptor with claims, expiration, issuer, and audience
        /// </summary>
        private SecurityTokenDescriptor CreateTokenDescriptor(
            List<Claim> claims, 
            SigningCredentials signingCredentials)
        {
            var expiryMinutes = double.Parse(_config["JwtSettings:ExpiryMinutes"] 
                ?? throw new InvalidOperationException("JWT ExpiryMinutes is not configured."));

            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
                Issuer = _config["JwtSettings:Issuer"] 
                    ?? throw new InvalidOperationException("JWT Issuer is not configured."),
                Audience = _config["JwtSettings:Audience"] 
                    ?? throw new InvalidOperationException("JWT Audience is not configured."),
                SigningCredentials = signingCredentials
            };
        }

        /// <summary>
        /// Generates the final JWT token string
        /// </summary>
        private string GenerateJwtToken(SecurityTokenDescriptor tokenDescriptor)
        {
            var tokenHandler = new JsonWebTokenHandler();
            return tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}