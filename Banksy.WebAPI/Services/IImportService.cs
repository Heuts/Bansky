using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services
{
    public interface IImportService
    {
        int ImportExcel(IFormFile file);
    }
}
