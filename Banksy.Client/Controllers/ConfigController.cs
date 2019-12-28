using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banksy.Client.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Banksy.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private IConfiguration config;

        public ConfigController(IConfiguration configuration)
        {
            config = configuration;
        }

        [HttpGet]
        public ConfigDto Index()
        {
            return new ConfigDto
            {
                ApiServerUrl = config["ApiServer:SchemeAndHost"],
            };
        }
    }
}