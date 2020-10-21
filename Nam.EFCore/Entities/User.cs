using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class User : AuditedEntity
    {

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string PassWord { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birth { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50)]
        public string SocialId { get; set; }

        [StringLength(20)]
        public string Provider { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Ratting> Evaluates { get; set; }
    }
}
