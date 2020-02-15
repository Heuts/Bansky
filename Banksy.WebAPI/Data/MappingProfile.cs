using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Mutation, DTOs.Mutation>();
            CreateMap<Models.Category, DTOs.Category>();
        }
    }
}
