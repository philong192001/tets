using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class CartDetail : AuditedEntity
    {
        public long CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
