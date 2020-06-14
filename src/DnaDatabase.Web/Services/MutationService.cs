using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnaDatabase.Web.Models;
using DnaDatabase.Web.Repositories;

namespace DnaDatabase.Web.Services
{
    public class MutationService : IMutationService
    {
        private readonly IMutationRepository _repository;

        public MutationService(IMutationRepository repository)
            => _repository = repository;

        public IAsyncEnumerable<MutationDto> GetAllMutations()
            => _repository.GetMany();

        public Task<MutationDto> GetMutation(string id)
            => _repository.Get(id);
    }
}
