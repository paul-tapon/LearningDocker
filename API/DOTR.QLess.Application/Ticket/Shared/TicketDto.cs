using DOTR.QLess.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Application.Ticket.Shared
{
    public class TicketDto : IMapFrom<Domain.Entities.Ticket>
    {
        public int TicketId { get; set; }
        public int TicketTypeId { get; set; }
        public string TicketTypeName { get; set; }
        public string TicketNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime ValidUntil { get; set; }
        public DateTime? LastUsedDate { get; set; }
    }
}
