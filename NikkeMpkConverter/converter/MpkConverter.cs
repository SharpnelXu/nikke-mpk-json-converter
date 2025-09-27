using MemoryPack;
using NikkeMpkConverter.model;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        /// <typeparam name="TItem">The item type contained in the collection (e.g., Word)</typeparam>
        /// <param name="inputPath">Path to the .mpk file</param>
        /// <param name="outputPath">Path where to save the JSON file (optional)</param>
        /// <param name="createContainer">Function to create a container from an array of items (optional)</param>
        /// <returns>The deserialized JsonTableContainer object</returns>
        public static async Task<JsonTableContainer<TItem>> ConvertMpkToJsonAsync<TItem>(
            string inputPath,
            string? outputPath = null,
            Func<TItem[], JsonTableContainer<TItem>>? createContainer = null,
            Action<TItem>? processItem = null)
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

            JsonTableContainer<TItem> container = new JsonTableContainer<TItem>();

            try
            {
                Console.WriteLine($"Trying to deserialize as {typeof(TItem).Name}[]...");
                var items = MemoryPackSerializer.Deserialize<TItem[]>(bytes);

                if (items != null)
                {
                    Console.WriteLine($"Successfully deserialized {items.Length} items");
                    if (processItem != null)
                    {
                        foreach (var item in items)
                        {
                            processItem(item);
                        }
                    }

                    // Create a container object from the items
                    if (createContainer != null)
                    {
                        container = createContainer(items);
                    }
                    else
                    {
                        // Set the Records property to the deserialized items
                        container.Records = items;
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
                    WriteIndented = true, // For pretty-printed JSON
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
        /// <typeparam name="TItem">The item type contained in the collection (e.g., Word)</typeparam>
        /// <param name="inputPath">Path to the JSON file</param>
        /// <param name="outputPath">Path where to save the MPK file (optional)</param>
        /// <param name="getItems">Function to extract items from the container (optional)</param>
        /// <returns>The serialized bytes</returns>
        public static async Task<byte[]> ConvertJsonToMpkAsync<TItem>(
            string inputPath,
            string? outputPath = null,
            Func<JsonTableContainer<TItem>, TItem[]>? getItems = null)
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

            JsonTableContainer<TItem> container;
            TItem[] items;

            try
            {
                var deserializedContainer = JsonSerializer.Deserialize<JsonTableContainer<TItem>>(jsonContent, jsonOptions);

                if (deserializedContainer == null)
                {
                    throw new InvalidOperationException($"Failed to deserialize JSON to JsonTableContainer<{typeof(TItem).Name}>");
                }

                container = deserializedContainer;

                // Extract items from the container
                if (getItems != null)
                {
                    items = getItems(container);
                }
                else
                {
                    // Use the Records property directly
                    if (container.Records == null)
                    {
                        throw new InvalidOperationException($"Records property is null in JsonTableContainer<{typeof(TItem).Name}>");
                    }
                    items = container.Records;
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
                mpkBytes = MemoryPackSerializer.Serialize(items);
                Console.WriteLine($"Successfully serialized to MPK format ({mpkBytes.Length} bytes)");
                // if (items.Length > 0)
                // {
                //     // Show example of first item for debugging
                //     byte[] sampleBytes = MemoryPackSerializer.Serialize(items[0]);
                //     Console.WriteLine($"First item hex dump: {BitConverter.ToString(sampleBytes, 0, Math.Min(sampleBytes.Length, 64)).Replace("-", " ")}");
                // }
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
                await ConvertMpkToJsonAsync<Word>(
                    inputPath,
                    outputPath,
                    (words) => new JsonTableContainer<Word> { Version = "0.0.1", Records = words }
                );
            }
            else if (extension == ".json")
            {
                await VerifyJsonToMpkConversion<Word>(
                    outputPath,
                    inputPath,
                    (container) => container.Records
                );
            }
            else
            {
                throw new ArgumentException($"Unsupported file extension: {extension}. Only .mpk and .json are supported.");
            }
        }

        public static async Task ConvertTableAsync<TItem>(
            string inputPath,
            string? outputPath = null,
            Action<List<string>, TItem, TItem>? logItemDetails = null,
            Func<TItem, TItem?, bool>? shouldSkipFailure = null, 
            Action<HashSet<string>, TItem>? checkMpkItemDetails = null,
            Func<TItem, long>? getMpkItemKey = null,
            Action<TItem>? processItem = null,
            bool stopOnFirstMismatch = true)
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
                await ConvertMpkToJsonAsync<TItem>(
                    inputPath,
                    outputPath,
                    (items) => new JsonTableContainer<TItem> { Version = "0.0.1", Records = items },
                    processItem
                );
            }
            else if (extension == ".json")
            {
                await VerifyJsonToMpkConversion<TItem>(
                    outputPath,
                    inputPath,
                    (container) => container.Records,
                    logItemDetails,
                    shouldSkipFailure,
                    checkMpkItemDetails,
                    getMpkItemKey,
                    stopOnFirstMismatch: stopOnFirstMismatch
                );
            }
            else
            {
                throw new ArgumentException($"Unsupported file extension: {extension}. Only .mpk and .json are supported.");
            }
        }

        /// <summary>
        /// Verifies that JSON objects can be correctly serialized to match the MPK format.
        /// Implements Stage 2 of the planning document, comparing individual records to check for enum fields.
        /// </summary>
        /// <typeparam name="TItem">The item type contained in the collection (e.g., Word)</typeparam>
        /// <param name="mpkPath">Path to the reference .mpk file</param>
        /// <param name="jsonPath">Path to the reference .json file</param>
        /// <param name="getItems">Function to extract items from the container (optional)</param>
        /// <param name="stopOnFirstMismatch">Whether to stop processing after the first mismatch is found</param>
        /// <returns>A tuple containing (bool success, List of mismatched indexes, Dictionary of mismatched field details)</returns>
        public static async Task<(bool Success, List<int> MismatchIndexes, Dictionary<int, List<string>> MismatchDetails)> VerifyJsonToMpkConversion<TItem>(
            string mpkPath,
            string jsonPath,
            Func<JsonTableContainer<TItem>, TItem[]>? getItems = null,
            Action<List<string>, TItem, TItem>? logItemDetails = null,
            Func<TItem, TItem?, bool>? shouldSkipFailure = null, 
            Action<HashSet<string>, TItem>? checkMpkItemDetails = null,
            Func<TItem, long>? getMpkItemKey = null,
            bool stopOnFirstMismatch = true)
        {
            Console.WriteLine($"Verifying JSON to MPK conversion compatibility...");
            Console.WriteLine($"MPK file: {mpkPath}");
            Console.WriteLine($"JSON file: {jsonPath}");

            // Read MPK file
            byte[] mpkBytes = await File.ReadAllBytesAsync(mpkPath);
            Console.WriteLine($"MPK file size: {mpkBytes.Length} bytes");

            // Skip the first 8 bytes (array length and possibly other header information)
            // As per planning.md Stage 2, point 2
            if (mpkBytes.Length < 8)
            {
                throw new InvalidOperationException("MPK file is too small - missing header information");
            }

            int arrayLength = BitConverter.ToInt32(mpkBytes, 0);
            Console.WriteLine($"Array length from MPK header: {arrayLength}");

            // Convert MPK bytes (after header) to hex string for comparison
            string mpkHex = BitConverter.ToString(mpkBytes, 4).Replace("-", " ");

            // Read and parse the JSON file
            string jsonContent = await File.ReadAllTextAsync(jsonPath);
            var jsonOptions = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true
            };

            // Deserialize the JSON to the container type
            JsonTableContainer<TItem>? container;
            TItem[]? items;

            try
            {
                container = JsonSerializer.Deserialize<JsonTableContainer<TItem>>(jsonContent, jsonOptions);

                if (container == null)
                {
                    throw new InvalidOperationException($"Failed to deserialize JSON to JsonTableContainer<{typeof(TItem).Name}>");
                }

                // Extract items from the container
                if (getItems != null)
                {
                    items = getItems(container);
                }
                else
                {
                    // Use the Records property directly
                    if (container.Records == null)
                    {
                        throw new InvalidOperationException($"Records property is null in JsonTableContainer<{typeof(TItem).Name}>");
                    }
                    items = container.Records;
                }

                if (items == null || items.Length == 0)
                {
                    throw new InvalidOperationException("No items found to verify");
                }

                Console.WriteLine($"Successfully loaded JSON with {items.Length} records");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error processing JSON: {ex.Message}", ex);
            }

            // Verification results
            bool overallSuccess = true;
            List<int> mismatchIndexes = new List<int>();
            Dictionary<int, List<string>> mismatchDetails = new Dictionary<int, List<string>>();

            // Track our position in the MPK hex string
            if (stopOnFirstMismatch)
            {
                // Sequential item matching
                int currentMpkPosition = 0;
                // Process each item individually to compare with MPK content
                for (int i = 0; i < items.Length; i++)
                {
                    if (i > 0 && i % 1000 == 0)
                    {
                        Console.WriteLine($"Processed {i} of {items.Length} records...");
                    }

                    // Serialize the current item with MemoryPack
                    byte[] itemBytes;
                    try
                    {
                        itemBytes = MemoryPackSerializer.Serialize(items[i]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error serializing item {i}: {ex.Message}");
                        overallSuccess = false;
                        mismatchIndexes.Add(i);
                        mismatchDetails[i] = new List<string> { $"Serialization error: {ex.Message}" };

                        if (stopOnFirstMismatch)
                        {
                            break;
                        }
                        continue;
                    }

                    // Convert item bytes to hex for comparison
                    string itemHex = BitConverter.ToString(itemBytes).Replace("-", " ");

                    // Check if we have enough MPK data left to compare
                    if (currentMpkPosition + itemBytes.Length * 3 - 1 > mpkHex.Length)
                    {
                        Console.WriteLine($"Warning: MPK data is shorter than expected at item {i}");
                        overallSuccess = false;
                        mismatchIndexes.Add(i);
                        mismatchDetails[i] = new List<string> { "MPK data is shorter than expected" };
                        break;
                    }

                    // Extract the corresponding portion from the MPK hex string
                    string mpkItemHex = mpkHex.Substring(currentMpkPosition, itemBytes.Length * 3 - 1);
                    var details = new List<string>();
                    TItem? mpkItem = default;

                    try
                    {
                        byte[] mpkItemBytes = new byte[itemBytes.Length];
                        for (int b = 0; b < itemBytes.Length; b++)
                        {
                            string byteHex = mpkItemHex.Substring(b * 3, 2);
                            mpkItemBytes[b] = Convert.ToByte(byteHex, 16);
                        }
                        mpkItem = MemoryPackSerializer.Deserialize<TItem>(mpkItemBytes);

                    }
                    catch (Exception ex)
                    {
                        details.Add($"Error deserializing MPK item for details: {ex.Message}");
                    }

                    // Compare the two hex strings
                    if (itemHex != mpkItemHex && (shouldSkipFailure == null || !shouldSkipFailure(items[i], mpkItem)))
                    {
                        overallSuccess = false;
                        mismatchIndexes.Add(i);

                        // Generate detailed mismatch information
                        details.Add($"Mismatch at record {i}");
                        if (stopOnFirstMismatch)
                        {
                            details.Add($"Expected (MPK): {mpkItemHex}");
                            details.Add($"Actual  (JSON): {itemHex}");
                        }

                        // Find exactly where the mismatch starts
                        int mismatchPos = 0;
                        while (mismatchPos < Math.Min(itemHex.Length, mpkItemHex.Length) &&
                            itemHex[mismatchPos] == mpkItemHex[mismatchPos])
                        {
                            mismatchPos++;
                        }

                        if (mismatchPos < Math.Min(itemHex.Length, mpkItemHex.Length))
                        {
                            details.Add($"First difference at position {mismatchPos}");

                            // Show context around the mismatch
                            int contextStart = Math.Max(0, mismatchPos - 15);
                            int contextLength = Math.Min(30, Math.Min(itemHex.Length, mpkItemHex.Length) - contextStart);

                            if (stopOnFirstMismatch)
                            {
                                details.Add($"MPK context: ...{mpkItemHex.Substring(contextStart, contextLength)}...");
                                details.Add($"JSON context: ...{itemHex.Substring(contextStart, contextLength)}...");
                                details.Add("This likely indicates a string field that should be an enum instead");
                            }
                        }
                        else
                        {
                            details.Add($"Difference in length: MPK={mpkItemHex.Length}, JSON={itemHex.Length}");
                        }

                        if (logItemDetails != null && mpkItem != null)
                        {
                            if (stopOnFirstMismatch)
                            {
                                details.Add($"Json details: {JsonSerializer.Serialize(items[i], new JsonSerializerOptions { WriteIndented = true })}");
                                details.Add($"MPK  details: {JsonSerializer.Serialize(mpkItem, new JsonSerializerOptions { WriteIndented = true })}");
                            }
                            logItemDetails(details, items[i], mpkItem);
                        }
                        mismatchDetails[i] = details;

                        if (stopOnFirstMismatch)
                        {
                            Console.WriteLine("Found mismatch. Stopping verification as requested.");
                            break;
                        }
                    }

                    // Move to the next position in the MPK hex string
                    currentMpkPosition += itemBytes.Length * 3;
                }
            }
            else
            {
                // try deserializing all items at once and comparing
                var mpkItems = MemoryPackSerializer.Deserialize<TItem[]>(mpkBytes);
                Dictionary<long, TItem> mpkItemMap = new Dictionary<long, TItem>();
                if (mpkItems != null)
                {
                    for (int i = 0; i < mpkItems.Length; i++)
                    {
                        if (getMpkItemKey != null)
                        {
                            long idValue = getMpkItemKey(mpkItems[i])!;
                            mpkItemMap[idValue] = mpkItems[i];
                            continue;
                        }
                        else
                        {
                            var idProperty = typeof(TItem).GetProperty("Id");
                            if (idProperty != null)
                            {
                                long idValue = (int)idProperty.GetValue(mpkItems[i])!;
                                mpkItemMap[idValue] = mpkItems[i];
                            }
                        }
                    }
                }

                for (int i = 0; i < items.Length; i++)
                {
                    if (i > 0 && i % 1000 == 0)
                    {
                        Console.WriteLine($"Processed {i} of {items.Length} records...");
                    }

                    // Serialize the current item with MemoryPack
                    byte[] itemBytes;
                    try
                    {
                        itemBytes = MemoryPackSerializer.Serialize(items[i]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error serializing item {i}: {ex.Message}");
                        overallSuccess = false;
                        mismatchIndexes.Add(i);
                        mismatchDetails[i] = new List<string> { $"Serialization error: {ex.Message}" };

                        if (stopOnFirstMismatch)
                        {
                            break;
                        }
                        continue;
                    }

                    // Convert item bytes to hex for comparison
                    string itemHex = BitConverter.ToString(itemBytes).Replace("-", " ");

                    long id = 0;
                    if (getMpkItemKey != null)
                    {
                        id = getMpkItemKey(items[i])!;
                    }
                    else
                    {
                        var idProperty = typeof(TItem).GetProperty("Id");
                        if (idProperty != null)
                        {
                            id = (int)idProperty.GetValue(items[i])!;
                        }
                    }
                    // Extract the corresponding portion from the MPK hex string
                    string mpkItemHex = mpkItemMap.TryGetValue(
                        id,
                        out var mpkItem) && mpkItem != null
                        ? BitConverter.ToString(MemoryPackSerializer.Serialize(mpkItem)).Replace("-", " ")
                        : "";
                    var details = new List<string>();

                    // Compare the two hex strings
                    if (itemHex != mpkItemHex && (shouldSkipFailure == null || !shouldSkipFailure(items[i], mpkItem)))
                    {
                        overallSuccess = false;
                        mismatchIndexes.Add(i);

                        // Generate detailed mismatch information
                        details.Add($"Mismatch at record {i}");
                        if (stopOnFirstMismatch)
                        {
                            details.Add($"Expected (MPK): {mpkItemHex}");
                            details.Add($"Actual  (JSON): {itemHex}");
                        }

                        // Find exactly where the mismatch starts
                        int mismatchPos = 0;
                        while (mismatchPos < Math.Min(itemHex.Length, mpkItemHex.Length) &&
                            itemHex[mismatchPos] == mpkItemHex[mismatchPos])
                        {
                            mismatchPos++;
                        }

                        if (mismatchPos < Math.Min(itemHex.Length, mpkItemHex.Length))
                        {
                            details.Add($"First difference at position {mismatchPos}");

                            // Show context around the mismatch
                            int contextStart = Math.Max(0, mismatchPos - 15);
                            int contextLength = Math.Min(30, Math.Min(itemHex.Length, mpkItemHex.Length) - contextStart);

                            if (stopOnFirstMismatch)
                            {
                                details.Add($"MPK  context: ...{mpkItemHex.Substring(contextStart, contextLength)}...");
                                details.Add($"JSON context: ...{itemHex.Substring(contextStart, contextLength)}...");
                                details.Add("This likely indicates a string field that should be an enum instead");
                            }
                        }
                        else
                        {
                            details.Add($"Difference in length: MPK={mpkItemHex.Length}, JSON={itemHex.Length}");
                        }

                        if (logItemDetails != null && mpkItem != null)
                        {
                            if (stopOnFirstMismatch)
                            {
                                details.Add($"Json details: {JsonSerializer.Serialize(items[i], new JsonSerializerOptions { WriteIndented = true })}");
                                details.Add($"MPK  details: {JsonSerializer.Serialize(mpkItem, new JsonSerializerOptions { WriteIndented = true })}");
                            }
                            logItemDetails(details, items[i], mpkItem);
                        }
                        mismatchDetails[i] = details;

                        if (stopOnFirstMismatch)
                        {
                            Console.WriteLine("Found mismatch. Stopping verification as requested.");
                            break;
                        }
                    }
                }

                if (mpkItems != null && checkMpkItemDetails != null)
                {
                    var details = new HashSet<string>();
                    for (int i = 0; i < mpkItems.Length; i++)
                    {
                        if (i > 0 && i % 1000 == 0)
                        {
                            Console.WriteLine($"Processed {i} of {mpkItems.Length} MPK records for detail check...");
                        }
                        checkMpkItemDetails(details, mpkItems[i]);
                    }
                    foreach (var detail in details)
                    {
                        Console.WriteLine(detail);
                    }
                }
            }


            // Report results
            if (overallSuccess)
            {
                Console.WriteLine($"Verification successful! All {items.Length} records match between JSON and MPK.");
            }
            else
            {
                Console.WriteLine($"Verification failed. Found {mismatchIndexes.Count} mismatches.");

                // Print details of the first few mismatches
                if (stopOnFirstMismatch)
                {
                    int detailLimit = Math.Min(20, mismatchIndexes.Count);
                    for (int i = 0; i < detailLimit; i++)
                    {
                        int index = mismatchIndexes[i];
                        Console.WriteLine($"--- Mismatch {i + 1} of {mismatchIndexes.Count} (record index {index}) ---");
                        foreach (string detail in mismatchDetails[index])
                        {
                            Console.WriteLine(detail);
                        }
                    }
                }
                else
                {
                    HashSet<string> uniqueDetails = new HashSet<string>();
                    foreach (var details in mismatchDetails)
                    {
                        foreach (var detail in details.Value)
                        {
                            if (detail.StartsWith("  "))
                            {
                                uniqueDetails.Add(detail);
                            }
                        }
                    }
                    uniqueDetails = uniqueDetails.OrderBy(d => d).ToHashSet();
                    foreach (var detail in uniqueDetails)
                    {
                        Console.WriteLine(detail);
                    }
                }
                
            }
                

            return (overallSuccess, mismatchIndexes, mismatchDetails);
        }
    }
}