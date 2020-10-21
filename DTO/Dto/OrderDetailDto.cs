using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class OrderDetailDto : Entity
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public long OrderId { get; set; }
    }
}
