﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Dtos.GetDtos
{
    public class ResponseLoginUserDto
    {
        public string EMail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
