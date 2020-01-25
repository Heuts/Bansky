using AutoMapper;
using Banksy.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services
{
    public class MutationService : IMutationService
    {
        private BanksyContext context;
        private IMapper mapper;

        public MutationService(BanksyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DTOs.Mutation>> GetAllMutations()
        {
            return await context.Mutations.Select(m => mapper.Map<DTOs.Mutation>(m)).ToListAsync();
        }
    }
}
