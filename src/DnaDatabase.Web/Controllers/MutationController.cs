using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DnaDatabase.Web.Models;
using DnaDatabase.Web.Services;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DnaDatabase.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName ="v1")]
    [Route("api/v1/[controller]")]
    public class MutationController : ControllerBase
    {
        private readonly IMutationService _mutationService;

        public MutationController(IMutationService mutationService)
            => _mutationService = mutationService;

        [HttpGet("/mutation/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MutationDto>> GetMutation(
            [FromRoute] string id)
        {
            var mutation = await _mutationService.GetMutation(id);
            return Ok(mutation);
        }

        [HttpGet("/mutations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IAsyncEnumerable<MutationDto> GetMutations()
            => _mutationService.GetAllMutations();
    }
}
