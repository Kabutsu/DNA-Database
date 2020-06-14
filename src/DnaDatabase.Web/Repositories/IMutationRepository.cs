using DnaDatabase.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnaDatabase.Web.Repositories
{
    public interface IMutationRepository
    {
        Task<MutationDto> Get(string id);
        IAsyncEnumerable<MutationDto> GetMany();
    }
}
