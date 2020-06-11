namespace DnaDatabase.Web.Models
{
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
