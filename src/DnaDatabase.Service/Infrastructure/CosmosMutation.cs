using DnaDatabase.Service.Models;
using Newtonsoft.Json;

namespace DnaDatabase.Service.Infrastructure
{
    internal sealed class CosmosMutation
    {
        [JsonProperty("id")]
        public string Chromosome { get; }
        [JsonProperty("partitionKey")]
        public string Range { get; }

        public string Reference { get; }
        public string Mutant { get; }
        public string Gene { get; }
        public VariantFunctionType VariantFunction { get; }
        public string AAChange { get; }
        public string DBSNP { get; }

        public CosmosMutation(
            string chromosome,
            string range,
            string reference,
            string mutant,
            string gene,
            VariantFunctionType variantFunction,
            string aachange,
            string dbsnp)
        {
            Chromosome = chromosome;
            Range = range;
            Reference = reference;
            Mutant = mutant;
            Gene = gene;
            VariantFunction = variantFunction;
            AAChange = aachange;
            DBSNP = dbsnp;
        }
    }
}
