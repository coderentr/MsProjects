using Core.Infrastructure.Dtos.GetDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Utilities.Security.JwtToken
{
    public interface ITokenHelper
    {
        string CreateToken(ResponseLoginUserDto model);
    }
}
