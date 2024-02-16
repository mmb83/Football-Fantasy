using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace Football_Fantasy;

public class JWT
{
    public static string decodeToken(string stringToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(stringToken);
        var x = jsonToken.Claims.First(claim => claim.Type == "UserName").Value;
        return x;
    }

    public static string generateToken(string userName)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("footbalfantasyshahed1402footbalfantasyshahed1402"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]  
        {
            new Claim("UserName",userName),
        };
        var token = new JwtSecurityToken(
            issuer: "http://localhost:3001",
            audience: "http://localhost:3001",
            claims,
            signingCredentials: credentials 
        );
        var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
        return stringToken;

    }
}