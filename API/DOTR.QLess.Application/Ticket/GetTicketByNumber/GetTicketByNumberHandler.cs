using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Application.Ticket.Shared;
using DOTR.QLess.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DOTR.QLess.Application.Ticket.GetTicketByNumber
{
    public class GetTicketByNumberHandler : IRequestHandler<GetTicketByNumber, TicketDto>
    {
        private readonly IQLessDbContext _context;
        private readonly IMapper _mapper;

        public GetTicketByNumberHandler(IQLessDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TicketDto> Handle(GetTicketByNumber request, CancellationToken cancellationToken)
        {
            var ticket = await _context
                            .Tickets
                            .AsNoTracking()
                            .Include(t => t.TicketType)
                            .FirstOrDefaultAsync(t => t.TicketNumber == request.TicketNumber);



            if (ticket == null) throw new RecordNotFoundException("Ticket", "TicketNumber", request.TicketNumber);

            TicketDto ticketDto = _mapper.Map<TicketDto>(ticket);


            ticketDto.ValidUntil = ticket.LastUsedDate.HasValue ?
                    ticket.LastUsedDate.Value.AddMonths(ticket.TicketType.ExpirationInMonths.GetValueOrDefault()) :
                    ticket.CreatedDate.AddMonths(ticket.TicketType.ExpirationInMonths.GetValueOrDefault());

            return ticketDto;
        }
    }

}
