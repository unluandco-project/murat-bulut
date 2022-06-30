using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.WebApi.Utilities
{
    public static class TokenTool
    {
        public static string Create()
        {
            var bytes = Encoding.UTF8.GetBytes("unlucotaskproject");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer:"http://localhost:5000/", 
                audience: "http://localhost:5000/",
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddMinutes(15), // token geçerlilik süresi 
                signingCredentials:credentials
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }
    }
}
