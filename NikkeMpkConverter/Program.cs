using NikkeMpkConverter.converter;
using NikkeMpkConverter.serialization;
using System;
using System.IO;
using System.Threading.Tasks;

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

                // Process command line arguments if provided
                if (args.Length >= 1)
                {
                    inputPath = args[0];
                    if (args.Length >= 2)
                    {
                        outputPath = args[1];
                    }
                }
                else
                {
                    // Default paths
                    string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
                    inputPath = Path.Combine(dataDir, "WordTable.mpk");
                    outputPath = null; // Let the converter determine the output path based on input extension
                }

                Console.WriteLine($"Input file: {inputPath}");
                
                // Ensure the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Error: Input file not found at {inputPath}");
                    return;
                }
                
                // Determine if this is MPK to JSON or JSON to MPK based on file extension
                string extension = Path.GetExtension(inputPath).ToLowerInvariant();
                
                if (extension != ".mpk" && extension != ".json")
                {
                    Console.WriteLine($"Error: Unsupported file extension: {extension}. Only .mpk and .json are supported.");
                    return;
                }
                
                // Generate default output path if not provided
                if (string.IsNullOrEmpty(outputPath))
                {
                    string outputExtension = extension == ".mpk" ? ".json" : ".mpk";
                    outputPath = Path.ChangeExtension(inputPath, outputExtension);
                }
                
                Console.WriteLine($"Output file: {outputPath}");

                // Convert the file (auto-detects format based on extension)
                await MpkConverter.ConvertWordTableAsync(inputPath, outputPath);
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
