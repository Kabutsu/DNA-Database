using DnaDatabase.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnaDatabase.Service.Services
{
    public interface IMutationService
    {
        Task<MutationDto> GetMutation(string id);
        IAsyncEnumerable<MutationDto> GetAllMutations();
    }
}
