using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnaDatabase.Service.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VariantFunctionType
    {
        Undefined,
        FrameshiftInsertion,
        FrameshiftSubstitution,
        FrameShiftDeletion,
        NonFrameshiftInsertion,
        NonFrameshiftSubstitution,
        NonFrameshiftDeletion,
        NonSynonymousSNV,
        Stopgain,
        Stoploss
    }
}
