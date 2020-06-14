using DnaDatabase.Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DnaDatabase.Service.Infrastructure
{
    internal static class StreamExtensionMethods
    {
        internal static async Task<IEnumerable<CosmosMutation>> TryGetCosmosMutationAsync(this Stream stream)
        {
            using (var streamCopy = new MemoryStream())
            {
                try
                {
                    await stream.CopyToAsync(streamCopy);
                    streamCopy.Position = 0;

                    using var reader = new StreamReader(streamCopy);
                    var value = JsonDocument
                        .Parse(
                            reader.ReadToEnd(),
                            new JsonDocumentOptions { AllowTrailingCommas = true })
                        .RootElement
                        .GetProperty("Documents");
                    var a = "a";
                    var mutations = value.EnumerateArray();
                    List<CosmosMutation> cosmosMutations = new List<CosmosMutation>();

                    foreach (var mutation in mutations)
                    {
                        var variantFunctionParseSuccess = Enum.TryParse(
                            mutation.GetProperty("VariantFunction").GetString(),
                            out VariantFunctionType variantFunction);

                        var cosmosMutation = new CosmosMutation(
                            mutation.GetProperty("id").GetString(),
                            mutation.GetProperty("partitionKey").GetString(),
                            mutation.GetProperty("Reference").GetString().ToCharArray()[0],
                            mutation.GetProperty("Mutant").GetString().ToCharArray()[0],
                            mutation.GetProperty("Gene").GetString(),
                            variantFunctionParseSuccess ? variantFunction : VariantFunctionType.Undefined,
                            mutation.GetProperty("AAChange").GetString(),
                            mutation.GetProperty("DBSNP").GetString());
                        cosmosMutations.Add(cosmosMutation);
                    }
                    return cosmosMutations;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
    }
}
