using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class Ratting : AuditedEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int? Quality { get; set; }

        [StringLength(100)]
        public string Content { get; set; }
    }
}
