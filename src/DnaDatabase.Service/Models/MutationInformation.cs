using System;

namespace DnaDatabase.Service.Models
{
    public class MutationInformation
    {
        public string Id { get; }
        public int Chromosome { get; }
        public Int32 Start { get; }
        public Int32 End { get; }
        public string Reference { get; }
        public string Mutant { get; }
        public string Gene { get; }
        public VariantFunctionType VariantFunction { get; }
        public string AAChange { get; }
        public string DBSNP { get; }

        public MutationInformation(
            string id,
            int chromosome,
            Int32 start,
            Int32 end,
            string reference,
            string mutant,
            string gene,
            VariantFunctionType variantFunction,
            string aaChange,
            string dbSnp)
        {
            Id = id;
            Chromosome = chromosome;
            Start = start;
            End = end;
            Reference = reference;
            Mutant = mutant;
            Gene = gene;
            VariantFunction = variantFunction;
            AAChange = aaChange;
            DBSNP = dbSnp;
        }
    }
}
