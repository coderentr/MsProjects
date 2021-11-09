using Core.Infrastructure.Dtos.GetDtos;
using Core.Infrastructure.Dtos.PostDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Utilities.Security.JwtToken
{
    public  class TokenHelper :ITokenHelper
    {
        readonly IConfiguration _configuration;
        private TokenOptions _tokenoptions = new TokenOptions();
        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenoptions.AccessTokenExpiration = Convert.ToInt32(_configuration.GetSection("TokenOptions").GetSection("AccessTokenExpiration").Value);
            _tokenoptions.Issuer = _configuration.GetSection("TokenOptions").GetSection("Issuer").Value;
            _tokenoptions.Audience = _configuration.GetSection("TokenOptions").GetSection("Audience").Value;
            _tokenoptions.SecurityKey = _configuration.GetSection("TokenOptions").GetSection("SecurityKey").Value;
        }
        public string CreateToken(ResponseLoginUserDto model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenoptions.SecurityKey);
            var securityKey = _tokenoptions.SecurityKey;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", model.Id.ToString()), new Claim("email", model.EMail)}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience=_tokenoptions.Audience,
                Issuer=_tokenoptions.Issuer,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
