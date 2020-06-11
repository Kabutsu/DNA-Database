using DnaDatabase.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnaDatabase.Web.Services
{
    public interface IMutationService
    {
        Task<MutationInformation> GetMutation(string id);
        Task<IEnumerable<MutationInformation>> GetAllMutations();
    }
}
