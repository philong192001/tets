using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class CartDto : Entity
    {
        public long UserId { get; set; }
        public List<CartDetailDto> CartDetails { get; set; }
    }
}
