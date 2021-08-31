using DOTR.QLess.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Application.TicketType.Shared
{
    public class TicketTypeDto : IMapFrom<DOTR.QLess.Domain.Entities.TicketType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal InitialLoad { get; set; }

        public decimal FixRate { get; set; }
    }
}
