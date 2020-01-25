using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services
{
    public interface IMutationService
    {
        Task<List<DTOs.Mutation>> GetAllMutations();
    }
}
