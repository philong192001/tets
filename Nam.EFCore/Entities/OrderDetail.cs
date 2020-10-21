using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class OrderDetail : Entity
    {
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}
