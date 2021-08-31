using AutoMapper;
using AutoMapper.QueryableExtensions;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Application.Ticket.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOTR.QLess.Application.Ticket.GetTicketById
{
    public class GetTicketById : IRequest<TicketDto>
    {
        public int TicketId { get; set; }
    }

    public class GetTicketByIdHandler : IRequestHandler<GetTicketById, TicketDto>
    {
        private readonly IQLessDbContext _context;
        private readonly IMapper _mapper;

        public GetTicketByIdHandler(IQLessDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TicketDto> Handle(GetTicketById request, CancellationToken cancellationToken)
        {
            var ticket = await _context
                            .Tickets
                            .AsNoTracking()
                            .Include(t=>t.TicketType)
                            .ProjectTo<TicketDto>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(t => t.TicketId == request.TicketId);

            return ticket;
        }
    }


}
