using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services
{
    public interface IMutationService
    {
        Task<List<DTOs.Mutation>> GetAllMutations();

        Task<List<Models.Mutation>> RemoveDuplicates(List<Models.Mutation> newMutations);

        Task<DTOs.Mutation> GetMutation(int id);

        Task<DTOs.Category> GetCategory(int id);
    }
}
