using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Dtos.PostDtos
{
    public class LoginUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
