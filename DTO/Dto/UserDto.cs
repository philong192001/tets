using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class UserDto : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
