using AutoMapper;

namespace Banksy.WebAPI.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Mutation, DTOs.Mutation>();
        }
    }
}
