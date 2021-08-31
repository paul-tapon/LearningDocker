using DOTR.QLess.Domain.Entities.Common;
using DOTR.QLess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Domain.Entities
{
    public class Ticket : AuditableEntity
    {
        public int TicketId { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
        public string TicketNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime? LastUsedDate { get; set; }
    }
}
