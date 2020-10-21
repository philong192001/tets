using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class UserInfoDto : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime? Birth { get; set; }

        public string Address { get; set; }
    }
}
