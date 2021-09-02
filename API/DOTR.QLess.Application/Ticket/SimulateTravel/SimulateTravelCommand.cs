using DOTR.QLess.Application.Ticket.Shared;
using DOTR.QLess.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Application.Ticket.SimulateTravel
{
    public class SimulateTravelCommand : IRequest<SimulateTravelResultDto>
    {
        public string TicketNumber { get; set; }
        public DateTime TravelDate { get; set; }
    }

}
