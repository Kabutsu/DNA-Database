using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnaDatabase.Service.Models;
using DnaDatabase.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DnaDatabase.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MutationsController : ControllerBase
    {
        private readonly IMutationService _mutationService;

        public MutationsController(IMutationService mutationService)
        {
            _mutationService = mutationService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MutationDto>> GetMutation(
            [FromRoute] string id)
        {
            var mutation = await _mutationService.GetMutation(id);
            return Ok(mutation);
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IAsyncEnumerable<MutationDto> GetMutations()
        {
            var mutations = _mutationService.GetAllMutations();
            return mutations;
        }
    }
}
