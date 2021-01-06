using System.Threading.Tasks;
using Banksy.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banksy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutationController : ControllerBase
    {
        private IMutationService mutationService;

        public MutationController(IMutationService mutationService)
        {
            this.mutationService = mutationService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMutations()
        {
            return Ok(await mutationService.GetAllMutations());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMutation(int id)
        {
            return Ok(await mutationService.GetMutation(id));
        }

        
        [HttpGet("total")]
        public async Task<IActionResult> GetTotalMutations()
        {
            return Ok(await mutationService.GetTotalMutations());
        }

        [HttpGet("page/{page}/{size}")]
        public async Task<IActionResult> GetMutationsByPageAndSize(int page, int size)
        {
            return Ok(await mutationService.GetMutationsByPageAndSize(page, size));
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Ok(await mutationService.GetCategory(id));
        }
    }
}