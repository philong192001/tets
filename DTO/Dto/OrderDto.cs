using Nam.EFCore.Auditing;
using Nam.EFCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class OrderDto : Entity
    {
        public long UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }

        public Pay PayType { get; set; }

        public string Address { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
