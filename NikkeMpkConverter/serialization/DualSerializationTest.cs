using MemoryPack;
using NikkeMpkConverter.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace NikkeMpkConverter.serialization
{
    /// <summary>
    /// Test utilities for dual serialization compatibility
    /// </summary>
    public static class DualSerializationTest
    {
        /// <summary>
        /// Tests that the Word model can be properly serialized and deserialized using both JSON and MemoryPack
        /// </summary>
        /// <param name="outputDir">Directory to save test output files</param>
        public static async Task TestDualSerializationAsync(string outputDir)
        {
            try
            {
                Console.WriteLine("Running dual serialization compatibility test...");
                Directory.CreateDirectory(outputDir);
                
                // Create a test WordTable with sample data
                var wordTable = new WordTable
                {
                    Version = "0.0.1",
                    Records = new Word[]
                    {
                        new Word
                        {
                            Id = 1,
                            Group = "test_group",
                            PageNumber = 1,
                            Order = 1,
                            ResourceType = ResourceType.Image,
                            ResourceValue = "test_resource_1"
                        },
                        new Word
                        {
                            Id = 2,
                            Group = "test_group",
                            PageNumber = 1,
                            Order = 2,
                            ResourceType = ResourceType.Locale,
                            ResourceValue = "test_resource_2"
                        }
                    }
                };
                
                // 1. Serialize to JSON
                var jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                
                string jsonOutputPath = Path.Combine(outputDir, "dual_test_json.json");
                string jsonString = JsonSerializer.Serialize(wordTable, jsonOptions);
                await File.WriteAllTextAsync(jsonOutputPath, jsonString);
                Console.WriteLine($"Serialized to JSON: {jsonOutputPath}");
                Console.WriteLine($"JSON content:\n{jsonString}");
                
                // 2. Serialize to MemoryPack
                string mpkOutputPath = Path.Combine(outputDir, "dual_test_mpk.mpk");
                byte[] mpkBytes = MemoryPackSerializer.Serialize(wordTable);
                await File.WriteAllBytesAsync(mpkOutputPath, mpkBytes);
                Console.WriteLine($"Serialized to MPK: {mpkOutputPath}");
                
                // 3. Deserialize from JSON back to WordTable
                string readJsonString = await File.ReadAllTextAsync(jsonOutputPath);
                var jsonDeserialized = JsonSerializer.Deserialize<WordTable>(readJsonString, jsonOptions);
                Console.WriteLine("Successfully deserialized from JSON back to WordTable");
                Console.WriteLine($"First record ID: {jsonDeserialized?.Records[0].Id}, Resource: {jsonDeserialized?.Records[0].ResourceValue}");
                
                // 4. Deserialize from MPK back to WordTable
                byte[] readMpkBytes = await File.ReadAllBytesAsync(mpkOutputPath);
                var mpkDeserialized = MemoryPackSerializer.Deserialize<WordTable>(readMpkBytes);
                Console.WriteLine("Successfully deserialized from MPK back to WordTable");
                Console.WriteLine($"First record ID: {mpkDeserialized?.Records[0].Id}, Resource: {mpkDeserialized?.Records[0].ResourceValue}");
                
                // 5. Cross-validation: Serialize JSON-deserialized object to MPK
                var crossMpkPath = Path.Combine(outputDir, "json_to_mpk.mpk");
                if (jsonDeserialized != null)
                {
                    byte[] crossMpkBytes = MemoryPackSerializer.Serialize(jsonDeserialized);
                    await File.WriteAllBytesAsync(crossMpkPath, crossMpkBytes);
                    Console.WriteLine("Cross-serialization: JSON-deserialized object to MPK successful");
                }
                
                // 6. Cross-validation: Serialize MPK-deserialized object to JSON
                var crossJsonPath = Path.Combine(outputDir, "mpk_to_json.json");
                if (mpkDeserialized != null)
                {
                    string crossJsonString = JsonSerializer.Serialize(mpkDeserialized, jsonOptions);
                    await File.WriteAllTextAsync(crossJsonPath, crossJsonString);
                    Console.WriteLine("Cross-serialization: MPK-deserialized object to JSON successful");
                }
                
                Console.WriteLine("Dual serialization test completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in dual serialization test: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}