using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using tocaaqui_backend.Domain.Users.Entities;

namespace tocaaqui_backend.Infrastructure.Auth;

public class JwtGenerator : IJwtGenerator
{
    private readonly IConfiguration _config;
    public JwtGenerator(IConfiguration config) => _config = config;

    public string Generate(User user)
    {
        var section = _config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(
                          Encoding.UTF8.GetBytes(section["Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email.Value),
            new Claim(ClaimTypes.Role, user.Role.ToString().ToLower())
        };

        var token = new JwtSecurityToken(
            issuer: section["Issuer"],
            audience: section["Audience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(
                          int.Parse(section["ExpiresMinutes"]!)),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
