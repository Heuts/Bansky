using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services
{
    public interface IMutationService
    {
        Task<List<DTOs.Mutation>> GetAllMutations();

        Task<DTOs.Mutation> GetMutation(int id);

        Task<DTOs.Category> GetCategory(int id);

        Task<List<DTOs.Mutation>> GetMutationsByPageAndSize(int page, int size);
        
        Task<int> GetTotalMutations();

        Task<List<Models.Mutation>> RemoveDuplicates(List<Models.Mutation> newMutations);

        Task<List<DTOs.Category>> GetAllCategories();
    }
}
