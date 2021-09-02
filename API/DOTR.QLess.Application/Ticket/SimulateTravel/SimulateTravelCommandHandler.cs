using AutoMapper;
using DOTR.QLess.Application.Common.Services;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Application.Ticket.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DOTR.QLess.Application.Ticket.SimulateTravel
{
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
                            .Include(t => t.TicketType)
                            .FirstOrDefaultAsync(t => t.TicketNumber == request.TicketNumber);

            result.PreviousBalance = ticket.Balance;
            result.TicketId = ticket.TicketId;
            result.LastUsedDate = request.TravelDate;
            result.TicketNumber = ticket.TicketNumber;
            result.TicketTypeId = ticket.TicketTypeId;
            result.TicketTypeName = ticket.TicketType.Name;
            result.NewBalance = ticket.Balance - ticket.TicketType.FixRate;

            ticket.Balance = ticket.Balance - ticket.TicketType.FixRate;
            ticket.LastUsedDate = request.TravelDate;

            await _qLessDbContext.SaveChangesAsync();

            result.Success = true;


            return result;
        }



    }

}
