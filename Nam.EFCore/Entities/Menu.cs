using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class Menu : FullAuditedEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(100)]
        public string SlugUrl { get; set; }

        public virtual ICollection<GroupProduct> ProductCategories { get; set; }
    }
}
