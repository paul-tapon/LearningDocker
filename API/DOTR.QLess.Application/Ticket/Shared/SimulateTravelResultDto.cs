using System;
namespace DOTR.QLess.Application.Ticket.Shared
{
    public class SimulateTravelResultDto
    {
        public int TicketId { get; set; }
        public int TicketTypeId { get; set; }
        public string TicketTypeName { get; set; }
        public string TicketNumber { get; set; }
        public decimal NewBalance { get; set; }
        public decimal PreviousBalance { get; set; }
        public DateTime? LastUsedDate { get; set; }
        public bool Success { get; set; }
    }
}
