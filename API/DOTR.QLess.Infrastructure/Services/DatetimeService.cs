using DOTR.QLess.Application.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Infrastructure.Services
{
    public class DatetimeService : IDateTimeService
    {
        public DateTime Now
        {
            get
            {
                 return DateTime.Now;
            }
        }
    }
}
