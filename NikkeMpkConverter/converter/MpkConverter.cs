using MemoryPack;
using NikkeMpkConverter.model;
using System.Text;
using System.Text.Json;

namespace NikkeMpkConverter.converter
{
    /// <summary>
    /// Handles conversion between MPK and JSON formats
    /// </summary>
    public static class MpkConverter
    {
        /// <summary>
        /// Deserializes a .mpk file and saves it as JSON
        /// </summary>
        /// <typeparam name="TContainer">The container type (e.g., WordTable)</typeparam>
        /// <typeparam name="TItem">The item type contained in the collection (e.g., Word)</typeparam>
        /// <param name="inputPath">Path to the .mpk file</param>
        /// <param name="outputPath">Path where to save the JSON file (optional)</param>
        /// <param name="createContainer">Function to create a container from an array of items</param>
        /// <returns>The deserialized container object</returns>
        public static async Task<TContainer> ConvertMpkToJsonAsync<TContainer, TItem>(
            string inputPath, 
            string? outputPath = null,
            Func<TItem[], TContainer>? createContainer = null) where TContainer : class, new()
        {
            Console.WriteLine($"Converting MPK to JSON: {inputPath}...");
            
            // Read all bytes from the .mpk file
            byte[] bytes = await File.ReadAllBytesAsync(inputPath);
            Console.WriteLine($"File size: {bytes.Length} bytes");
            
            // Display file header for diagnostics
            Console.WriteLine("First 16 bytes in hex:");
            StringBuilder hexDump = new StringBuilder();
            for (int i = 0; i < Math.Min(16, bytes.Length); i++)
            {
                hexDump.Append($"{bytes[i]:X2} ");
            }
            Console.WriteLine(hexDump.ToString());
            
            if (bytes.Length >= 4)
            {
                int arrayLength = BitConverter.ToInt32(bytes, 0);
                Console.WriteLine($"First 4 bytes as Int32 (array length): {arrayLength}");
            }
            
            TContainer container = new TContainer();
            
            try
            {
                Console.WriteLine($"Trying to deserialize as {typeof(TItem).Name}[]...");
                var items = MemoryPackSerializer.Deserialize<TItem[]>(bytes);
                
                if (items != null)
                {
                    Console.WriteLine($"Successfully deserialized {items.Length} items");
                    
                    // Create a container object from the items
                    if (createContainer != null)
                    {
                        container = createContainer(items);
                    }
                    else
                    {
                        // Try to find and set a "Records" property if available
                        var recordsProperty = typeof(TContainer).GetProperty("Records");
                        if (recordsProperty != null && recordsProperty.PropertyType == typeof(TItem[]))
                        {
                            recordsProperty.SetValue(container, items);
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Failed to deserialize MPK as {typeof(TItem).Name}[]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
                
                throw new InvalidOperationException("Error deserializing MPK file", ex);
            }
            
            // If outputPath is provided, save the result as JSON
            if (!string.IsNullOrEmpty(outputPath))
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true // For pretty-printed JSON
                };
                
                string jsonString = JsonSerializer.Serialize(container, jsonOptions);
                await File.WriteAllTextAsync(outputPath, jsonString);
                
                Console.WriteLine($"Conversion complete. Output saved to {outputPath}");
            }
            
            return container;
        }
        
        /// <summary>
        /// Converts a JSON file to MPK format
        /// </summary>
        /// <typeparam name="TContainer">The container type (e.g., WordTable)</typeparam>
        /// <typeparam name="TItem">The item type contained in the collection (e.g., Word)</typeparam>
        /// <param name="inputPath">Path to the JSON file</param>
        /// <param name="outputPath">Path where to save the MPK file (optional)</param>
        /// <param name="getItems">Function to extract items from the container</param>
        /// <returns>The serialized bytes</returns>
        public static async Task<byte[]> ConvertJsonToMpkAsync<TContainer, TItem>(
            string inputPath, 
            string? outputPath = null,
            Func<TContainer, TItem[]>? getItems = null) where TContainer : class
        {
            Console.WriteLine($"Converting JSON to MPK: {inputPath}...");
            
            // Read the JSON file
            string jsonContent = await File.ReadAllTextAsync(inputPath);
            
            // Deserialize the JSON to the container type
            var jsonOptions = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true
            };
            
            TContainer container;
            TItem[] items;
            
            try
            {
                var deserializedContainer = JsonSerializer.Deserialize<TContainer>(jsonContent, jsonOptions);
                
                if (deserializedContainer == null)
                {
                    throw new InvalidOperationException($"Failed to deserialize JSON to {typeof(TContainer).Name}");
                }
                
                container = deserializedContainer;
                
                // Extract items from the container
                if (getItems != null)
                {
                    items = getItems(container);
                }
                else
                {
                    // Try to find a "Records" property if available
                    var recordsProperty = typeof(TContainer).GetProperty("Records");
                    if (recordsProperty != null && recordsProperty.PropertyType == typeof(TItem[]))
                    {
                        var recordsValue = recordsProperty.GetValue(container);
                        if (recordsValue == null)
                        {
                            throw new InvalidOperationException($"Records property is null in {typeof(TContainer).Name}");
                        }
                        items = (TItem[])recordsValue;
                    }
                    else
                    {
                        throw new InvalidOperationException($"No 'Records' property found in {typeof(TContainer).Name} and no getItems function provided");
                    }
                }
                
                if (items == null || items.Length == 0)
                {
                    throw new InvalidOperationException("No items found to serialize");
                }
                
                Console.WriteLine($"Successfully deserialized JSON with {items.Length} items");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error deserializing JSON: {ex.Message}", ex);
            }
            
            // Serialize to MemoryPack format
            byte[] mpkBytes;
            try
            {
                mpkBytes = MemoryPackSerializer.Serialize(items[0]);
                Console.WriteLine($"Hex dump: {BitConverter.ToString(mpkBytes, 0, mpkBytes.Length).Replace("-", " ")}");
                Console.WriteLine($"Successfully serialized to MPK format ({mpkBytes.Length} bytes)");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error serializing to MPK: {ex.Message}", ex);
            }
            
            // If outputPath is provided, save the result as MPK
            if (!string.IsNullOrEmpty(outputPath))
            {
                await File.WriteAllBytesAsync(outputPath, mpkBytes);
                Console.WriteLine($"Conversion complete. Output saved to {outputPath}");
            }
            
            return mpkBytes;
        }
        
        /// <summary>
        /// Determines the format of the input file and converts to the opposite format
        /// </summary>
        /// <param name="inputPath">Path to the input file (.mpk or .json)</param>
        /// <param name="outputPath">Path where to save the output file (optional)</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public static async Task ConvertWordTableAsync(string inputPath, string? outputPath = null)
        {
            // Determine the input and output formats based on file extension
            string extension = Path.GetExtension(inputPath).ToLowerInvariant();
            
            // Generate output path if not provided
            if (string.IsNullOrEmpty(outputPath))
            {
                string outputExtension = extension == ".mpk" ? ".json" : ".mpk";
                outputPath = Path.ChangeExtension(inputPath, outputExtension);
            }
            
            // Convert based on input format
            if (extension == ".mpk")
            {
                await ConvertMpkToJsonAsync<WordTable, Word>(
                    inputPath, 
                    outputPath,
                    (words) => new WordTable { Version = "0.0.1", Records = words }
                );
            }
            else if (extension == ".json")
            {
                await ConvertJsonToMpkAsync<WordTable, Word>(
                    inputPath, 
                    outputPath,
                    (container) => container.Records
                );
            }
            else
            {
                throw new ArgumentException($"Unsupported file extension: {extension}. Only .mpk and .json are supported.");
            }
        }
    }
}