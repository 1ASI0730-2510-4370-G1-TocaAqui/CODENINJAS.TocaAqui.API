using System.Security.Claims;
using System.Text;
using CODENINJAS.TocaAqui.API.IAM.Application.Internal.OutboundServices;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace CODENINJAS.TocaAqui.API.IAM.Infrastructure.Tokens.JWT.Services;

public class TokenService(IOptions<TokenSettings> options) : ITokenService
{
    private readonly string _secret = options.Value.Secret;

    // -----------------------------------------------------------
    public string GenerateToken(User user)
    {
        var creds = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)),
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Sid,  user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var handler = new JsonWebTokenHandler();
        return handler.CreateToken(tokenDescriptor);
    }

    // -----------------------------------------------------------
    public async Task<int?> ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return null;

        var handler = new JsonWebTokenHandler();
        var result  = await handler.ValidateTokenAsync(token, new TokenValidationParameters
        {
            ValidateIssuer           = false,
            ValidateAudience         = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)),
            ClockSkew                = TimeSpan.Zero
        });

        if (!result.IsValid || result.SecurityToken is not JsonWebToken jwt)
            return null;
            
        return int.Parse(jwt.Claims.First(c => c.Type == ClaimTypes.Sid).Value);
    }
}
