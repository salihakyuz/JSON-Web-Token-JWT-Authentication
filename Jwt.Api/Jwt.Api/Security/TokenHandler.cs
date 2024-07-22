using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;


using Jwt.Api.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;

namespace Jwt.Api.Security
{
    public static class TokenHandler
    {
        public static Token CreateToken(IConfiguration configuration) 
        { //in Iconfiguration we save to Token's options
            Token token = new();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Securitykey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);//we use hmac algorithm for the signature
            token.Expration = DateTime.Now.AddMinutes(Convert.ToInt16(configuration["Token:Expiration"]));

            JwtSecurityToken tokenSecurityToken = new JwtSecurityToken(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],  
                expires: token.Expration,
                notBefore: DateTime.Now,
                signingCredentials:credentials
                );
            JwtSecurityToken securityToken2 = new();

            var tokenHandler = new JwtSecurityTokenHandler();

            //token.AccesToken = TokenHandler.WriteToken(JwtSecurityToken);
            token.AccesToken = tokenHandler.WriteToken(tokenSecurityToken);

            byte[] numbers = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(numbers);
            token.refreshtoken = Convert.ToBase64String(numbers);

            return token;

        }
    } 
}
