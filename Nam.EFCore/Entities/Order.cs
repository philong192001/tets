using Nam.EFCore.Auditing;
using Nam.EFCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class Order : AuditedEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public bool Status { get; set; }

        public Pay PayType { get; set; }
        
        [StringLength(200)]
        public string Address { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
