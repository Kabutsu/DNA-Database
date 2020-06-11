using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DnaDatabase.Web.Models;
using DnaDatabase.Web.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DnaDatabase.Web.Controllers
{
    public class MutationController : Controller
    {
        private readonly MutationService _mutationService;

        public MutationController(MutationService mutationService)
            => _mutationService = mutationService;

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<MutationInformation>> GetMutation(string id)
        {
            return await _mutationService.GetMutation(id);
        }

        public async Task<ActionResult<IEnumerable<MutationInformation>>> GetMutations()
        {
            return await _mutationService.GetAllMutations();
        }
    }
}
