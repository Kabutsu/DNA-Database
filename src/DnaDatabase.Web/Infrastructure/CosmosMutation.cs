using DnaDatabase.Web.Models;
using Newtonsoft.Json;

namespace DnaDatabase.Web.Infrastructure
{
    internal class CosmosMutation
    {
        [JsonProperty("id")]
        public string Chromosome { get; }
        [JsonProperty("partitionKey")]
        public string Range { get; }

        public char Reference { get; }
        public char Mutant { get; }
        public string Gene { get; }
        public VariantFunctionType VariantFunction { get; }
        public string AAChange { get; }
        public string DBSNP { get; }
    }
}
