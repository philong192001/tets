using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.UserDto
{
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
