using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banksy.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banksy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private IImportService importService;

        public ImportController (IImportService importService)
        {
            this.importService = importService;
        }

        [DisableRequestSizeLimit]
        public async Task<ActionResult> UploadFilesAsync()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    await Task.Run(() => importService.ImportExcel(file));
                }
                return Ok(file.Name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}