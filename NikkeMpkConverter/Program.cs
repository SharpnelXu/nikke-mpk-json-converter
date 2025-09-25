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
                await SerializationAsync(inputPath, outputPath!, inputExtension, outputExtension);
                
                // await MpkConverter.ConvertTableAsync<FavoriteItemData>(
                //     inputPath + "FavoriteItemTable" + inputExtension,
                //     outputPath + "FavoriteItemTable" + outputExtension,
                //     (details, jsonItem, mpkItem) =>
                //     {
                //         if (jsonItem.Id != mpkItem.Id)
                //         {
                //             details.Add($"ID Mismatch: Json {jsonItem.Id} vs MPK {mpkItem.Id}");
                //         }
                //         else
                //         {
                //             details.Add($"ID: {jsonItem.Id}");
                //             // if (jsonItem.OriginalRare != mpkItem.OriginalRare)
                //             // {
                //             //     details.Add($"  OriginalRare Mismatch: Json ({jsonItem.OriginalRare}) vs MPK ({(int) mpkItem.OriginalRare})");
                //             // }
                //         }
                //     },
                //     stopOnFirstMismatch: true
                // );
                
                Console.WriteLine("Conversion completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        static async Task SerializationAsync(string inputPath, string outputPath, string inputExtension, string outputExtension)
        {
            await MpkConverter.ConvertTableAsync<Word>(inputPath + "WordTable" + inputExtension, outputPath + "WordTable" + outputExtension);
            await MpkConverter.ConvertTableAsync<UnionRaidPreset>(inputPath + "UnionRaidPresetTable" + inputExtension, outputPath + "UnionRaidPresetTable" + outputExtension);
            await MpkConverter.ConvertTableAsync<AttractiveLevelTable>(inputPath + "AttractiveLevelTable" + inputExtension, outputPath + "AttractiveLevelTable" + outputExtension);
            await MpkConverter.ConvertTableAsync<CharacterStatEnhance>(inputPath + "CharacterStatEnhanceTable" + inputExtension, outputPath + "CharacterStatEnhanceTable" + outputExtension);
            await MpkConverter.ConvertTableAsync<CharacterShotTable>(
                inputPath + "CharacterShotTable" + inputExtension,
                outputPath + "CharacterShotTable" + outputExtension,
                (details, jsonItem, mpkItem) =>
                {
                    if (jsonItem.Id != mpkItem.Id)
                    {
                        details.Add($"ID Mismatch: Json {jsonItem.Id} vs MPK {mpkItem.Id}");
                    }
                    else
                    {
                        details.Add($"ID: {jsonItem.Id}");
                        if (jsonItem.WeaponType != mpkItem.WeaponType)
                        {
                            details.Add($"  WeaponType Mismatch: Json ({jsonItem.WeaponType}) vs MPK ({(int)mpkItem.WeaponType})");
                        }
                        if (jsonItem.AttackType != mpkItem.AttackType)
                        {
                            details.Add($"  AttackType Mismatch: Json ({jsonItem.AttackType}) vs MPK ({(int)mpkItem.AttackType})");
                        }
                        if (jsonItem.CounterEnermy != mpkItem.CounterEnermy)
                        {
                            details.Add($"  CounterEnermy Mismatch: Json ({jsonItem.CounterEnermy}) vs MPK ({(int)mpkItem.CounterEnermy})");
                        }
                        if (jsonItem.PreferTarget != mpkItem.PreferTarget)
                        {
                            details.Add($"  PreferTarget Mismatch: Json ({jsonItem.PreferTarget}) vs MPK ({(int)mpkItem.PreferTarget})");
                        }
                        if (jsonItem.PreferTargetCondition != mpkItem.PreferTargetCondition)
                        {
                            details.Add($"  PreferTargetCondition Mismatch: Json ({jsonItem.PreferTargetCondition}) vs MPK ({(int)mpkItem.PreferTargetCondition})");
                        }
                        if (jsonItem.FireType != mpkItem.FireType)
                        {
                            details.Add($"  FireType Mismatch: Json ({jsonItem.FireType}) vs MPK ({(int)mpkItem.FireType})");
                        }
                        if (jsonItem.InputType != mpkItem.InputType)
                        {
                            details.Add($"  InputType Mismatch: Json ({jsonItem.InputType}) vs MPK ({(int)mpkItem.InputType})");
                        }
                        if (jsonItem.ShakeType != mpkItem.ShakeType)
                        {
                            details.Add($"  ShakeType Mismatch: Json ({jsonItem.ShakeType}) vs MPK ({(int)mpkItem.ShakeType})");
                        }
                    }
                }
            );
            await MpkConverter.ConvertTableAsync<SkillData>(
                inputPath + "CharacterSkillTable" + inputExtension,
                outputPath + "CharacterSkillTable" + outputExtension,
                (details, jsonItem, mpkItem) =>
                {
                    if (jsonItem.Id != mpkItem.Id)
                    {
                        details.Add($"ID Mismatch: Json {jsonItem.Id} vs MPK {mpkItem.Id}");
                    }
                    else
                    {
                        details.Add($"ID: {jsonItem.Id}");
                        if (jsonItem.AttackType != mpkItem.AttackType)
                        {
                            details.Add($"  AttackType Mismatch: Json ({jsonItem.AttackType}) vs MPK ({(int)mpkItem.AttackType})");
                        }
                        if (jsonItem.CounterType != mpkItem.CounterType)
                        {
                            details.Add($"  CounterType Mismatch: Json ({jsonItem.CounterType}) vs MPK ({(int)mpkItem.CounterType})");
                        }
                        if (jsonItem.PreferTarget != mpkItem.PreferTarget)
                        {
                            details.Add($"  PreferTarget Mismatch: Json ({jsonItem.PreferTarget}) vs MPK ({(int)mpkItem.PreferTarget})");
                        }
                        if (jsonItem.PreferTargetCondition != mpkItem.PreferTargetCondition)
                        {
                            details.Add($"  PreferTargetCondition Mismatch: Json ({jsonItem.PreferTargetCondition}) vs MPK ({(int)mpkItem.PreferTargetCondition})");
                        }
                        if (jsonItem.SkillType != mpkItem.SkillType)
                        {
                            details.Add($"  SkillType Mismatch: Json ({jsonItem.SkillType}) vs MPK ({(int)mpkItem.SkillType})");
                        }
                        if (jsonItem.DurationType != mpkItem.DurationType)
                        {
                            details.Add($"  DurationType Mismatch: Json ({jsonItem.DurationType}) vs MPK ({(int)mpkItem.DurationType})");
                        }
                    }
                }
            );

            await MpkConverter.ConvertTableAsync<CharacterStat>(
                inputPath + "CharacterStatTable" + inputExtension,
                outputPath + "CharacterStatTable" + outputExtension
            );

            await MpkConverter.ConvertTableAsync<NikkeCharacterData>(
                inputPath + "CharacterTable" + inputExtension,
                outputPath + "CharacterTable" + outputExtension,
                (details, jsonItem, mpkItem) =>
                {
                    if (jsonItem.Id != mpkItem.Id)
                    {
                        details.Add($"ID Mismatch: Json {jsonItem.Id} vs MPK {mpkItem.Id}");
                    }
                    else
                    {
                        details.Add($"ID: {jsonItem.Id}");
                        if (jsonItem.OriginalRare != mpkItem.OriginalRare)
                        {
                            details.Add($"  OriginalRare Mismatch: Json ({jsonItem.OriginalRare}) vs MPK ({(int)mpkItem.OriginalRare})");
                        }
                        if (jsonItem.CharacterClass != mpkItem.CharacterClass)
                        {
                            details.Add($"  NikkeClass Mismatch: Json ({jsonItem.CharacterClass}) vs MPK ({(int)mpkItem.CharacterClass})");
                        }
                        if (jsonItem.UseBurstSkill != mpkItem.UseBurstSkill)
                        {
                            details.Add($"  BurstStep Mismatch: Json ({jsonItem.UseBurstSkill}) vs MPK ({(int)mpkItem.UseBurstSkill})");
                        }
                        if (jsonItem.ChangeBurstStep != mpkItem.ChangeBurstStep)
                        {
                            details.Add($"  BurstStep Mismatch: Json ({jsonItem.ChangeBurstStep}) vs MPK ({(int)mpkItem.ChangeBurstStep})");
                        }
                        if (jsonItem.Skill1Table != mpkItem.Skill1Table)
                        {
                            details.Add($"  SkillType Mismatch: Json ({jsonItem.Skill1Table}) vs MPK ({(int)mpkItem.Skill1Table})");
                        }
                        if (jsonItem.Skill2Table != mpkItem.Skill2Table)
                        {
                            details.Add($"  SkillType Mismatch: Json ({jsonItem.Skill2Table}) vs MPK ({(int)mpkItem.Skill2Table})");
                        }
                        if (jsonItem.EffCategoryType != mpkItem.EffCategoryType)
                        {
                            details.Add($"  EffCategoryType Mismatch: Json ({jsonItem.EffCategoryType}) vs MPK ({(int)mpkItem.EffCategoryType})");
                        }
                        if (jsonItem.CategoryType1 != mpkItem.CategoryType1)
                        {
                            details.Add($"  CategoryType Mismatch: Json ({jsonItem.CategoryType1}) vs MPK ({(int)mpkItem.CategoryType1})");
                        }
                        if (jsonItem.CategoryType2 != mpkItem.CategoryType2)
                        {
                            details.Add($"  CategoryType Mismatch: Json ({jsonItem.CategoryType2}) vs MPK ({(int)mpkItem.CategoryType2})");
                        }
                        if (jsonItem.CategoryType3 != mpkItem.CategoryType3)
                        {
                            details.Add($"  CategoryType Mismatch: Json ({jsonItem.CategoryType3}) vs MPK ({(int)mpkItem.CategoryType3})");
                        }
                        if (jsonItem.Corporation != mpkItem.Corporation)
                        {
                            details.Add($"  Corporation Mismatch: Json ({jsonItem.Corporation}) vs MPK ({(int)mpkItem.Corporation})");
                        }
                        if (jsonItem.CorporationSubType != mpkItem.CorporationSubType)
                        {
                            details.Add($"  CorporationSubType Mismatch: Json ({jsonItem.CorporationSubType}) vs MPK ({(int)mpkItem.CorporationSubType})");
                        }
                        if (jsonItem.Squad != mpkItem.Squad)
                        {
                            details.Add($"  Squad Mismatch: Json ({jsonItem.Squad}) vs MPK ({(int)mpkItem.Squad})");
                        }
                    }
                },
                stopOnFirstMismatch: false
            );

            await MpkConverter.ConvertTableAsync<CoverStatEnhance>(
                inputPath + "CoverStatEnhanceTable" + inputExtension,
                outputPath + "CoverStatEnhanceTable" + outputExtension
            );

            await MpkConverter.ConvertTableAsync<CurrencyData>(
                inputPath + "CurrencyTable" + inputExtension,
                outputPath + "CurrencyTable" + outputExtension
            );

            await MpkConverter.ConvertTableAsync<CustomPackageSlotData>(
                inputPath + "CustomPackageGroupTable" + inputExtension,
                outputPath + "CustomPackageGroupTable" + outputExtension
            );

            await MpkConverter.ConvertTableAsync<CustomPackageShopData>(
                inputPath + "CustomPackageShopTable" + inputExtension,
                outputPath + "CustomPackageShopTable" + outputExtension
            );

            await MpkConverter.ConvertTableAsync<FavoriteItemLevelData>(
                inputPath + "FavoriteItemLevelTable" + inputExtension,
                outputPath + "FavoriteItemLevelTable" + outputExtension
            );
            
            await MpkConverter.ConvertTableAsync<FavoriteItemData>(
                inputPath + "FavoriteItemTable" + inputExtension,
                outputPath + "FavoriteItemTable" + outputExtension
            );
        }
    }
}
