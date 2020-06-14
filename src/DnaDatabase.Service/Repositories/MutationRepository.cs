using System.Collections.Generic;
using System.Threading.Tasks;
using DnaDatabase.Service.Infrastructure;
using DnaDatabase.Service.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace DnaDatabase.Service.Repositories
{
    internal class MutationRepository : IMutationRepository
    {
        private readonly Container _container;

        public MutationRepository(CosmosClient client, IOptions<MutationsDbOptions> options)
        {
            var databaseResponse = client
                .CreateDatabaseIfNotExistsAsync(options.Value.DatabaseName)
                .GetAwaiter()
                .GetResult();
            _container = databaseResponse.Database
                .CreateContainerIfNotExistsAsync(
                    new ContainerProperties(options.Value.ContainerName, "/partitionKey"))
                .GetAwaiter()
                .GetResult();
        }

        public async Task<MutationDto> Get(string id)
        {
            var idComponents = id.Split(":");

            var chromosome = idComponents[0];
            var range = $"{idComponents[1]}:{idComponents[2]}";

            var mutation = await GetEntity(chromosome, range);

            return Hydrate(mutation);
        }

        public async IAsyncEnumerable<MutationDto> GetMany()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var mutations = _container
                .GetItemQueryIterator<CosmosMutation>(query)
                .ToAsyncEnumerable();
                
            await foreach (var mutation in mutations)
            {
                yield return Hydrate(mutation);
            }
        }

        private async Task<CosmosMutation> GetEntity(string chromosome, string range)
            => (await _container.ReadItemAsync<CosmosMutation>(
                    chromosome,
                    new PartitionKey(range))).Resource;

        private static MutationDto Hydrate(CosmosMutation mutation)
            => new MutationDto(
                int.Parse(mutation.Chromosome),
                int.Parse(mutation.Range.Split(":")[0]),
                int.Parse(mutation.Range.Split(":")[1]),
                mutation.Reference,
                mutation.Mutant,
                mutation.Gene,
                mutation.VariantFunction,
                mutation.AAChange,
                mutation.DBSNP);
    }

    internal class MutationsDbOptions
    {
        public string DatabaseName { get; set; } = "";
        public string ContainerName { get; set; } = "";
    }

    internal static class FeedIteratorExtensions
    {
        internal static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(this FeedIterator<T> feedIterator)
        {
            while (feedIterator.HasMoreResults)
            {
                foreach (var item in await feedIterator.ReadNextAsync())
                {
                    yield return item;
                }
            }
        }
    }
}
