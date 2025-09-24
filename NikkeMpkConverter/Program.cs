using NikkeMpkConverter.converter;
using NikkeMpkConverter.serialization;
using NikkeMpkConverter.model;

namespace NikkeMpkConverter
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Nikke MPK Converter");

            try
            {
                // Check if we're in dual serialization test mode
                if (args.Length > 0 && args[0].Equals("--test-dual", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Running dual serialization compatibility test...");
                    
                    // Get output directory
                    string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "NikkeMpkConverter", "output", "dual-test");
                    if (args.Length > 1)
                    {
                        outputDir = args[1];
                    }
                    
                    // Run the dual serialization test
                    await DualSerializationTest.TestDualSerializationAsync(outputDir);
                    Console.WriteLine("Dual serialization test completed!");
                    return;
                }
            
                
                // Normal conversion mode
                string inputPath;
                string? outputPath = null;
                bool mpkToJson = true; // Default conversion direction

                // Process command line arguments if provided
                if (args.Length >= 1)
                {
                    inputPath = args[0];
                    if (args.Length >= 2)
                    {
                        outputPath = args[1];
                    }
                    if (args.Length >= 3)
                    {
                        mpkToJson = args[2].Equals("--mpk2json", StringComparison.OrdinalIgnoreCase);
                    }

                }
                else
                {
                    throw new ArgumentException("Please provide the input file path as the first argument. Optionally, provide the output file path as the second argument.");
                }

                Console.WriteLine($"Input file: {inputPath}");
                
                string inputExtension = mpkToJson ? ".mpk" : ".json";
                string outputExtension = mpkToJson ? ".json" : ".mpk";
                
                Console.WriteLine($"Output file: {outputPath}");

                // Convert the file (auto-detects format based on extension)
                // await MpkConverter.ConvertTableAsync<Word>(inputPath + "WordTable" + inputExtension, outputPath + "WordTable" + outputExtension);
                await MpkConverter.ConvertTableAsync<UnionRaidPreset>(inputPath + "UnionRaidPresetTable" + inputExtension, outputPath + "UnionRaidPresetTable" + outputExtension);
                Console.WriteLine("Conversion completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
