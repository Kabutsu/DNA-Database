using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DnaDatabase.Web.Models;

namespace DnaDatabase.Web.Repositories
{
    public class MutationRepository : IMutationRepository
    {
        public Task<MutationDto> Get(string chromosome, int start, int end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MutationDto>> GetMany()
        {
            throw new NotImplementedException();
        }
    }
}
