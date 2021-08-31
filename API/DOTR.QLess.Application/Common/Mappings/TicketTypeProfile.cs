using AutoMapper;
using DOTR.QLess.Application.TicketType.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Application.Common.Mappings
{
    public class TicketTypeProfile : Profile
    {
        public TicketTypeProfile()
        {
            CreateTicketTypeDtoMappings();
        }

        private void CreateTicketTypeDtoMappings()
        {
            CreateMap<DOTR.QLess.Domain.Entities.TicketType, TicketTypeDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(a => a.TicketTypeId))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(a => a.Name));
        }
    }
}
