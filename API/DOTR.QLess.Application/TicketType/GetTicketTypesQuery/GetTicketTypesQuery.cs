using AutoMapper;
using AutoMapper.QueryableExtensions;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Application.TicketType.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOTR.QLess.Application.TicketType.GetTicketTypesQuery
{
    public class GetTicketTypesQuery : IRequest<List<TicketTypeDto>>
    {
    }

    public class GetTicketTypesQueryHandler : IRequestHandler<GetTicketTypesQuery, List<TicketTypeDto>>
    {
        private readonly IQLessDbContext _context;
        private readonly IMapper _mapper;

        public GetTicketTypesQueryHandler(IQLessDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<TicketTypeDto>> Handle(GetTicketTypesQuery request, CancellationToken cancellationToken)
        {
            var ticketTypes = _context
                                .TicketTypes
                                .AsNoTracking()
                                .ProjectTo<TicketTypeDto>(_mapper.ConfigurationProvider);

            return ticketTypes.ToListAsync();
        }
    }
}
