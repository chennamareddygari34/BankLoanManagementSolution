﻿using BankLoanManagement.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankLoanManagement.Services
{
    public class TokenService : ITokenService
    {
        byte[] key;
        public TokenService(IConfiguration configuration)
        {
            key = Encoding.UTF8.GetBytes(configuration.GetValue(typeof(string), "TokenKey").ToString());
        }
        #region  generate Toke
        public string GenerateToken(string username)
        {
            string token = string.Empty;
            //Username for the token - from the parameter
            //Role is the role from parameter
            var subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
               
            });
            var tokenDescription = new SecurityTokenDescriptor();
            //Describing the token
            tokenDescription.Subject = subject;
            tokenDescription.Expires = DateTime.UtcNow.AddMinutes(30);
            var signature = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            tokenDescription.SigningCredentials = signature;
            var tokenHandler = new JwtSecurityTokenHandler();
            //Generating the token object
            var tokenObject = tokenHandler.CreateToken(tokenDescription);
            //Getting the t oken as string from the object
            token = tokenHandler.WriteToken(tokenObject);
            return token;
        }
        #endregion
    }
}
