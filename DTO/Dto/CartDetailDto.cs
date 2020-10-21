using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class CartDetailDto : Entity
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
    }
}
