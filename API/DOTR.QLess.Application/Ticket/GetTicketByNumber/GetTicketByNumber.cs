using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Application.Ticket.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DOTR.QLess.Application.Ticket.GetTicketByNumber
{
    public class GetTicketByNumber:IRequest<TicketDto>
    {
        public string TicketNumber { get; set; }
    }

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
                            .ProjectTo<TicketDto>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(t => t.TicketNumber == request.TicketNumber);

            return ticket;
        }
    }

}
