using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services.Interfaces
{
    public interface IMutationService
    {
        Task<List<DTOs.Mutation>> GetAllMutations();

        Task<DTOs.Mutation> GetMutation(int id);

        Task<DTOs.Category> GetCategory(int id);

        Task<List<DTOs.Mutation>> GetMutationsByPageAndSize(int page, int size);
        
        Task<int> GetTotalMutations();

        Task<List<Models.Mutation>> RemoveDuplicates(List<Models.Mutation> newMutations);
    }
}
