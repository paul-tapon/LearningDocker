using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Domain.Entities.Common
{
    public abstract class AuditableEntity
    {
        public int CreatedByAppUserId { get; set; }

        public AppUser CreatedByAppUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? LastModifiedByAppUserId { get; set; }

        public AppUser LastModifiedByAppUser { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
