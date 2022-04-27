using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace HouseRentApi.Sevices;

public class TokenGenerator
{
    private readonly IdentityUser _user;
    private readonly string _role;

    public TokenGenerator(IdentityUser user, string role)
    {
        _user = user;
        _role = role;
    }

    public async Task<string> Generate()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, _user.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, _role)
        };
        
        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            
        var issuer = "example.com";
        var audience = "example.com";
        var securityKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes("This is super secret key for example.com"));
        var credentials = new SigningCredentials(securityKey, 
            SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: issuer, 
            audience: audience, 
            claims: claims,
            signingCredentials: credentials);
        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }

    
}