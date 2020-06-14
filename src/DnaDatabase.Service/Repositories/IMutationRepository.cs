using DnaDatabase.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnaDatabase.Service.Repositories
{
    public interface IMutationRepository
    {
        Task<MutationDto> Get(string id);
        IAsyncEnumerable<MutationDto> GetMany();
    }
}
