using AutoMapper;
using DOTR.QLess.Application.Ticket.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Application.Common.Mappings
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateTicketDtoMappings();
        }

        private void CreateTicketDtoMappings()
        {
            CreateMap<Domain.Entities.Ticket, TicketDto>()
                .ForMember(
                    dest => dest.TicketTypeName,
                    opt => opt.MapFrom(a => a.TicketType.Name))
                .ForMember(
                    dest => dest.LastUsedDate,
                    opt => opt.MapFrom(a => a.LastUsedDate));

        }
    }
}
