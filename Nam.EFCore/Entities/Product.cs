using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class Product : FullAuditedEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int Quantity { get; set; }

        [StringLength(100)]
        public string SlugUrl { get; set; }

        public long GroupProductId { get; set; }
        public virtual GroupProduct GroupProduct { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Ratting> Rattings { get; set; }
    }
}
