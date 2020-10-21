using Microsoft.IdentityModel.Tokens;
using Nam.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nam.ULTILS.JWTToken
{
    public static class AuthenticationToken
    {
        public static string CreateJWTToken(User input)
        {
            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, input.UserName),
                //new Claim(JwtRegisteredClaimNames.Email, input.Email)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("I have created a LoginController and Login"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("Test.com",
            "Test.com",
            claim,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            string result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
