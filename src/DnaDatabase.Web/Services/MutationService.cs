using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnaDatabase.Web.Models;

namespace DnaDatabase.Web.Services
{
    public class MutationService : IMutationService
    {
        public async Task<IEnumerable<MutationInformation>> GetAllMutations()
        {
            throw new NotImplementedException();
        }

        public async Task<MutationInformation> GetMutation(string id)
        {
            throw new NotImplementedException();
        }
    }
}
