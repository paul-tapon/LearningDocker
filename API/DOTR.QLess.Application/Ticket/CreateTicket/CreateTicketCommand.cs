using DOTR.QLess.Domain.Entities;
using DOTR.QLess.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Application.Ticket.CreateTicket
{
    public class CreateTicketCommand : IRequest<int>
    {
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public int TicketType { get; set; }
    }
}
