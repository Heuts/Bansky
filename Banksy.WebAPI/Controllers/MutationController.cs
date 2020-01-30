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
    }
}