using AutoMapper;
using Banksy.WebAPI.Data;
using Banksy.WebAPI.DTOs;
using Banksy.WebAPI.Models;
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

        public async Task<DTOs.Mutation> GetMutation(int id)
        {
            var mutation = await context.Mutations.SingleAsync(m => m.Id == id);
            return mapper.Map<DTOs.Mutation>(mutation);
        }

        public async Task<List<Models.Mutation>> RemoveDuplicates(List<Models.Mutation> newMutations)
        {
            var existingMutations = await context.Mutations.ToArrayAsync();
            return newMutations.Except(existingMutations).ToList();
        }
    }
}
