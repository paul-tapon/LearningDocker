using AutoMapper;
using DOTR.QLess.Application.Common.Services;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOTR.QLess.Application.Ticket.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand,int>
    {
        private readonly IQLessDbContext _qLessDbContext;
        private readonly IMapper _mapper;
        private readonly IDateTimeService _dateTimeService;

        public CreateTicketCommandHandler(IQLessDbContext qLessDbContext, IMapper mapper, IDateTimeService dateTimeService)
        {
            _qLessDbContext = qLessDbContext;
            _mapper = mapper;
            _dateTimeService = dateTimeService;
        }

        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            int seedValue = GetNextSeedValue();

            var ticketType = _qLessDbContext.TicketTypes.FirstOrDefault(tt => tt.TicketTypeId == request.TicketType);
            string ticketNumber = $"{_dateTimeService.Now.Year}{_dateTimeService.Now.Month.ToString().PadLeft(2,'0')}{seedValue}";

            var ticket = new Domain.Entities.Ticket
            {
                Balance = ticketType.InitialLoad,
                TicketTypeId = ticketType.TicketTypeId,
                CreatedDate = _dateTimeService.Now,
                IsActive = true,
                CreatedByAppUserId = 1,
                TicketNumber = ticketNumber
            };

            _qLessDbContext.Tickets.Add(ticket);
            await _qLessDbContext.SaveChangesAsync();

            return ticket.TicketId;
        }

        private int GetNextSeedValue()
        {
            var seeder = _qLessDbContext
                            .TicketNumberSeeder
                            .FirstOrDefault(ts => ts.Month == _dateTimeService.Now.Month && ts.Year == _dateTimeService.Now.Year);
            int seedValue = 0;
            if (seeder == null)
            {
                seedValue = 1;

                var seederInitial = new TicketNumberSeeder()
                {
                    Month = _dateTimeService.Now.Month,
                    Year = _dateTimeService.Now.Year,
                    SeedValue = seedValue,
                };

                _qLessDbContext.TicketNumberSeeder.Add(seederInitial);
            }
            else
            {
                seedValue = seeder.SeedValue+1;
                seeder.SeedValue = seedValue;
            }

            return seedValue;

        }

    }
}
