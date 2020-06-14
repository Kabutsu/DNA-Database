using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnaDatabase.Web.Models
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
