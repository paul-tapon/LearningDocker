using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Application.Common.Mappings
{
    internal interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
