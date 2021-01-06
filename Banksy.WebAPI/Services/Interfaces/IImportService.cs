using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services.Interfaces
{
    public interface IImportService
    {
        Task<int> ImportExcel(IFormFile file);
    }
}
