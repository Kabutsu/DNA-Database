using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnaDatabase.Service.Models;
using DnaDatabase.Service.Services;
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

        [HttpGet("all")]
        public IAsyncEnumerable<MutationDto> GetMutations()
        {
            var mutations = _mutationService.GetAllMutations();
            return mutations;
        }
    }
}
