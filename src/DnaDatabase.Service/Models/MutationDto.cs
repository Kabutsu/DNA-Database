using System;

namespace DnaDatabase.Service.Models
{
    public class MutationDto
    {
        public int Chromosome { get; }
        public Int32 Start { get; }
        public Int32 End { get; }
        public string Reference { get; }
        public string Mutant { get; }
        public string Gene { get; }
        public string VariantFunction { get; }
        public string AAChange { get; }
        public string DBSNP { get; }

        public MutationDto(
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
            Chromosome = chromosome;
            Start = start;
            End = end;
            Reference = reference;
            Mutant = mutant;
            Gene = gene;
            VariantFunction = variantFunction.ToString();
            AAChange = aaChange;
            DBSNP = dbSnp;
        }
    }
}
