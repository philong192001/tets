using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class GroupProduct : FullAuditedEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Image { get; set; }
            
        [StringLength(200)]
        public string SlugUrl { get; set; }

        public long MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
