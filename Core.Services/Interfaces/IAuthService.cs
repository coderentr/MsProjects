using Core.Infrastructure.Dtos.GetDtos;
using Core.Infrastructure.Dtos.PostDtos;
using Core.Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IAuthService
    {
        DataResult<ResponseLoginUserDto> Login(LoginUserDto model);
        Result Register(RegisterUserDto model);
    }
}
