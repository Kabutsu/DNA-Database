using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnaDatabase.Service.Models
{
    public class MutationDto
    {
        public int Chromosome { get; }
        public Int32 Start { get; }
        public Int32 End { get; }
        public char Reference { get; }
        public char Mutant { get; }
        public string Gene { get; }
        public VariantFunctionType VariantFunction { get; }
        public string AAChange { get; }
        public string DBSNP { get; }

        public MutationDto(
            int chromosome,
            Int32 start,
            Int32 end,
            char reference,
            char mutant,
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
            VariantFunction = variantFunction;
            AAChange = aaChange;
            DBSNP = dbSnp;
        }

        public MutationInformation Convert()
            => new MutationInformation(
                $"{Chromosome}:{Start}:{End}",
                Chromosome,
                Start,
                End,
                Reference,
                Mutant,
                Gene,
                VariantFunction,
                AAChange,
                DBSNP);
    }
}
