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
            return await context.Mutations
                .Select(m => mapper.Map<DTOs.Mutation>(m))
                .ToListAsync();
        }

        public async Task<DTOs.Mutation> GetMutation(int id)
        {
            var mutation = await context.Mutations.SingleAsync(m => m.Id == id);
            return mapper.Map<DTOs.Mutation>(mutation);
        }
        public async Task<DTOs.Category> GetCategory(int id)
        {
            var category = await context.Categories.SingleAsync(c => c.Id == id);
            return mapper.Map<DTOs.Category>(category);
        }

        public async Task<List<DTOs.Mutation>> GetMutationsByPageAndSize(int page, int size)
        {
            // New performing code thanks to Willem
            return await context.Mutations
                .Where(x => context.Mutations
                    .OrderByDescending(m => m.Date)
                    .Select(y => y.Id)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .Contains(x.Id))
                .Select(m => mapper.Map<DTOs.Mutation>(m))
                .ToListAsync();

            // Old non performing code

            //return await context.Mutations
            //    .OrderByDescending(m => m.Date)
            //    .Skip((page - 1) * size)
            //    .Take(size)
            //    .Select(m => mapper.Map<DTOs.Mutation>(m))
            //    .ToListAsync();
        }

        public async Task<int> GetTotalMutations()
        {
            return await context.Mutations.CountAsync();
        }

        public async Task<List<Models.Mutation>> RemoveDuplicates(List<Models.Mutation> newMutations)
        {
            return newMutations
                .Except(await context.Mutations.ToArrayAsync())
                .ToList();
        }
    }
}
