using System;
using AutoMapper.QueryableExtensions;
using DOTR.QLess.Application.Ticket.Shared;
using MediatR;

namespace DOTR.QLess.Application.Ticket.GetTicketByNumber
{
    public class GetTicketByNumber:IRequest<TicketDto>
    {
        public string TicketNumber { get; set; }
    }

}
