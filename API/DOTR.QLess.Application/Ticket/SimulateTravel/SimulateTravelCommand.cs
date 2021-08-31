using AutoMapper;
using DOTR.QLess.Application.Common.Services;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Application.Ticket.Shared;
using DOTR.QLess.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOTR.QLess.Application.Ticket.SimulateTravel
{
    public class SimulateTravelCommand : IRequest<SimulateTravelResultDto>
    {
        public string TicketNumber { get; set; }
    }

    public class SimulateTravelCommandHandler : IRequestHandler<SimulateTravelCommand, SimulateTravelResultDto>
    {
        private readonly IQLessDbContext _qLessDbContext;
        private readonly IMapper _mapper;
        private readonly IDateTimeService _dateTimeService;

        public SimulateTravelCommandHandler(IQLessDbContext qLessDbContext, IMapper mapper, IDateTimeService dateTimeService)
        {
            _qLessDbContext = qLessDbContext;
            _mapper = mapper;
            _dateTimeService = dateTimeService;
        }

        public async Task<SimulateTravelResultDto> Handle(SimulateTravelCommand request, CancellationToken cancellationToken)
        {
            var result = new SimulateTravelResultDto()
            {
                Success = false
            };

            var ticket = await _qLessDbContext
                            .Tickets
                            .Include(t=>t.TicketType)
                            .FirstOrDefaultAsync(t => t.TicketNumber == request.TicketNumber);

            if (ticket.Balance < ticket.TicketType.FixRate)
            {

            }
            else
            {
                result.PreviousBalance = ticket.Balance;
                result.TicketId = ticket.TicketId;
                result.LastUsedDate = _dateTimeService.Now;
                result.TicketNumber = ticket.TicketNumber;
                result.TicketTypeId = ticket.TicketTypeId;
                result.TicketTypeName = ticket.TicketType.Name;
                result.NewBalance = ticket.Balance - ticket.TicketType.FixRate;
                ticket.Balance = ticket.Balance - ticket.TicketType.FixRate;

                await _qLessDbContext.SaveChangesAsync();

                result.Success = true;

            }

            return result;
        }



    }


}
