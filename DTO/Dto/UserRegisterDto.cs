using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
