using DnaDatabase.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnaDatabase.Web.Services
{
    public interface IMutationService
    {
        Task<MutationDto> GetMutation(string id);
        IAsyncEnumerable<MutationDto> GetAllMutations();
    }
}
