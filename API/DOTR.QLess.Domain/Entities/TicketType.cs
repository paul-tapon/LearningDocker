using DOTR.QLess.Domain.Entities.Common;
using DOTR.QLess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Domain.Entities
{
    public class TicketType : AuditableEntity
    {
        public int TicketTypeId { get; set; }

        public string Name { get; set; }

        public decimal InitialLoad { get; set; }

        public decimal FixRate { get; set; }
    }
}
