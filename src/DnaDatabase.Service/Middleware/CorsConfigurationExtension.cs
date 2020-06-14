using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System.Linq;

namespace DnaDatabase.Service.Middleware
{
    public static class CorsConfigurationExtension
    {
        public const string DefaultCorsPolicy = nameof(DefaultCorsPolicy);

        public static IServiceCollection ConfigureCorsSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
                options.AddPolicy(
                    DefaultCorsPolicy,
                    builder => builder
                        .WithOrigins(ExtractOrigins(configuration))
                        .WithMethods(HttpMethod.Get.ToString(), HttpMethod.Post.ToString())
                        .WithHeaders(HeaderNames.Authorization, HeaderNames.Accept, HeaderNames.ContentType, HeaderNames.Origin)));

            return services;
        }

        private static string[] ExtractOrigins(IConfiguration configuration)
        {
            return configuration
                .GetSection("Cors")
                .GetValue<string>("AllowedOrigins")
                .Split(";")
                .Select(o => o.TrimEnd('/'))
                .ToArray();
        }
    }
}
