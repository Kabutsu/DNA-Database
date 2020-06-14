using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DnaDatabase.Web.Models;
using DnaDatabase.Web.Repositories;
using DnaDatabase.Web.Services;

namespace DnaDatabase.Web.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MutationsDbOptions>(
                options =>
                {
                    options.DatabaseName = configuration["MutationsCosmosDatabase:Database"];
                    options.ContainerName = configuration["MutationsCosmosDatabase:Container"];
                });

            services.AddSingleton(
                typeof(CosmosClient),
                new CosmosClient(
                    configuration["MutationsCosmosDatabase:Endpoint"],
                    configuration["MutationsCosmosDatabase:Key"]));

            services.AddSingleton<IMutationService, MutationService>();
            services.AddSingleton<IMutationRepository, MutationRepository>();

            return services;
        }
    }
}
