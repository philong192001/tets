using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class Slider : FullAuditedEntity
    {
        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(100)]
        public string DisplayContent { get; set; }

        [StringLength(100)]
        public string Link { get; set; }
    }
}
