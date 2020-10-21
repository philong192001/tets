using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class Cart : AuditedEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
