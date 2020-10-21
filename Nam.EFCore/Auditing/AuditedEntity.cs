using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nam.EFCore.Auditing
{
    public abstract class AuditedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual long? ModifiedBy { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTime? DeletedDate { get; set; }

        public virtual long? DeletedBy { get; set; }
    }
}
