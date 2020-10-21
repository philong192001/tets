using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class MenuDto : Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string SlugUrl { get; set; }
    }
}
