using Bagdxk.Profile.Service.Api.Models;
using Bagdxk.Profile.Service.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bagdxk.Profile.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutsController : ControllerBase
    {
        private ILayoutRepository layoutRepository;

        public LayoutsController(ILayoutRepository layoutRepository)
        {
            this.layoutRepository = layoutRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Layout>> GetAsync(string id)
        {
            var result = await layoutRepository.GetAsync(id);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Layout>> SaveAsync(string id, [FromBody]Layout layout)
        {
            var result = await layoutRepository.SaveAsync(layout);
            return result;
        }
    }
}
