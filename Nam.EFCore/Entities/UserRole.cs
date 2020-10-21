using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.EFCore.Entities
{
    public class UserRole : FullAuditedEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
