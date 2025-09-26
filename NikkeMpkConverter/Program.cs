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

                // await MpkConverter.ConvertTableAsync<ConsumeItemData>(
                //     inputPath + "ItemConsumeTable" + inputExtension,
                //     outputPath + "ItemConsumeTable" + outputExtension,
                //     (details, jsonItem, mpkItem) =>
                //     {
                //         if (jsonItem.Id != mpkItem.Id)
                //         {
                //             details.Add($"ID Mismatch: Json {jsonItem.Id} vs MPK {mpkItem.Id}");
                //         }
                //         else
                //         {
                //             details.Add($"ID: {jsonItem.Id}");
                //             if (jsonItem.UseConditionType != mpkItem.UseConditionType)
                //             {
                //                 details.Add($"  UseConditionType Mismatch: Json ({jsonItem.UseConditionType}) vs MPK ({(int)mpkItem.UseConditionType})");
                //             }
                //             if (jsonItem.UseType != mpkItem.UseType)
                //             {
                //                 details.Add($"  UseType Mismatch: Json ({jsonItem.UseType}) vs MPK ({(int)mpkItem.UseType})");
                //             }
                //             if (jsonItem.ItemType != mpkItem.ItemType)
                //             {
                //                 details.Add($"  ItemType Mismatch: Json ({jsonItem.ItemType}) vs MPK ({(int)mpkItem.ItemType})");
                //             }
                //             if (jsonItem.ItemSubType != mpkItem.ItemSubType)
                //             {
                //                 details.Add($"  ItemSubType Mismatch: Json ({jsonItem.ItemSubType}) vs MPK ({(int)mpkItem.ItemSubType})");
                //             }
                //             if (jsonItem.ItemRarity != mpkItem.ItemRarity)
                //             {
                //                 details.Add($"  Rarity Mismatch: Json ({jsonItem.ItemRarity}) vs MPK ({(int)mpkItem.ItemRarity})");
                //             }
                //             if (jsonItem.PercentDisplayType != mpkItem.PercentDisplayType)
                //             {
                //                 details.Add($"  PercentDisplayType Mismatch: Json ({jsonItem.PercentDisplayType}) vs MPK ({(int)mpkItem.PercentDisplayType})");
                //             }
                //         }
                //     },
                //     checkMpkItemDetails: (details, mpkItem) =>
                //     {
                //         if (Enum.IsDefined(typeof(UseConditionType), (int)mpkItem.UseConditionType) == false)
                //         {
                //             details.Add($"  Unknown UseConditionType in MPK: {(int)mpkItem.UseConditionType}");
                //         }
                //         if (Enum.IsDefined(typeof(UseType), (int)mpkItem.UseType) == false)
                //         {
                //             details.Add($"  Unknown UseType in MPK: {(int)mpkItem.UseType}");
                //         }
                //         if (Enum.IsDefined(typeof(ItemType), (int)mpkItem.ItemType) == false)
                //         {
                //             details.Add($"  Unknown ItemType in MPK: {(int)mpkItem.ItemType}");
                //         }
                //         if (Enum.IsDefined(typeof(ItemSubType), (int)mpkItem.ItemSubType) == false)
                //         {
                //             details.Add($"  Unknown ItemSubType in MPK: {(int)mpkItem.ItemSubType}");
                //         }
                //         if (Enum.IsDefined(typeof(ItemRarity), (int)mpkItem.ItemRarity) == false)
                //         {
                //             details.Add($"  Unknown ItemRarity in MPK: {(int)mpkItem.ItemRarity}");
                //         }
                //         if (Enum.IsDefined(typeof(PercentDisplayType), (int)mpkItem.PercentDisplayType) == false)
                //         {
                //             details.Add($"  Unknown PercentDisplayType in MPK: {(int)mpkItem.PercentDisplayType}");
                //         }
                //     },
                //     stopOnFirstMismatch: false
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
                }
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

            await MpkConverter.ConvertTableAsync<FunctionData>(
                inputPath + "FunctionTable" + inputExtension,
                outputPath + "FunctionTable" + outputExtension,
                (details, jsonItem, mpkItem) =>
                {
                    if (jsonItem.Id != mpkItem.Id)
                    {
                        details.Add($"ID Mismatch: Json {jsonItem.Id} vs MPK {mpkItem.Id}");
                    }
                    else
                    {
                        details.Add($"ID: {jsonItem.Id}, GroupID: {jsonItem.GroupId}");
                        if (jsonItem.BuffType != mpkItem.BuffType)
                        {
                            details.Add($"  BuffType Mismatch: Json ({jsonItem.BuffType}) vs MPK ({(int)mpkItem.BuffType})");
                        }
                        if (jsonItem.BuffRemoveType != mpkItem.BuffRemoveType)
                        {
                            details.Add($"  BuffRemoveType Mismatch: Json ({jsonItem.BuffRemoveType}) vs MPK ({(int)mpkItem.BuffRemoveType})");
                        }
                        if (jsonItem.FunctionType != mpkItem.FunctionType)
                        {
                            details.Add($"  FunctionType Mismatch: Json ({jsonItem.FunctionType}) vs MPK ({(int)mpkItem.FunctionType})");
                        }
                        if (jsonItem.FunctionValueType != mpkItem.FunctionValueType)
                        {
                            details.Add($"  ValueType Mismatch: Json ({jsonItem.FunctionValueType}) vs MPK ({(int)mpkItem.FunctionValueType})");
                        }
                        if (jsonItem.FunctionStandard != mpkItem.FunctionStandard)
                        {
                            details.Add($"  StandardType Mismatch: Json ({jsonItem.FunctionStandard}) vs MPK ({(int)mpkItem.FunctionStandard})");
                        }
                        if (jsonItem.DelayType != mpkItem.DelayType)
                        {
                            details.Add($"  DurationType Mismatch: Json ({jsonItem.DelayType}) vs MPK ({(int)mpkItem.DelayType})");
                        }
                        if (jsonItem.DurationType != mpkItem.DurationType)
                        {
                            details.Add($"  DurationType Mismatch: Json ({jsonItem.DurationType}) vs MPK ({(int)mpkItem.DurationType})");
                        }
                        if (jsonItem.FunctionTarget != mpkItem.FunctionTarget)
                        {
                            details.Add($"  FunctionTargetType Mismatch: Json ({jsonItem.FunctionTarget}) vs MPK ({(int)mpkItem.FunctionTarget})");
                        }
                        if (jsonItem.TimingTriggerType != mpkItem.TimingTriggerType)
                        {
                            details.Add($"  TimingTriggerType Mismatch: Json ({jsonItem.TimingTriggerType}) vs MPK ({(int)mpkItem.TimingTriggerType})");
                        }
                        if (jsonItem.TimingTriggerStandard != mpkItem.TimingTriggerStandard)
                        {
                            details.Add($"  StandardType Mismatch: Json ({jsonItem.TimingTriggerStandard}) vs MPK ({(int)mpkItem.TimingTriggerStandard})");
                        }
                        if (jsonItem.StatusTriggerType != mpkItem.StatusTriggerType)
                        {
                            details.Add($"  StatusTriggerType Mismatch: Json ({jsonItem.StatusTriggerType}) vs MPK ({(int)mpkItem.StatusTriggerType})");
                        }
                        if (jsonItem.StatusTriggerStandard != mpkItem.StatusTriggerStandard)
                        {
                            details.Add($"  StandardType Mismatch: Json ({jsonItem.StatusTriggerStandard}) vs MPK ({(int)mpkItem.StatusTriggerStandard})");
                        }
                        if (jsonItem.StatusTrigger2Type != mpkItem.StatusTrigger2Type)
                        {
                            details.Add($"  StatusTriggerType Mismatch: Json ({jsonItem.StatusTrigger2Type}) vs MPK ({(int)mpkItem.StatusTrigger2Type})");
                        }
                        if (jsonItem.StatusTrigger2Standard != mpkItem.StatusTrigger2Standard)
                        {
                            details.Add($"  StandardType Mismatch: Json ({jsonItem.StatusTrigger2Standard}) vs MPK ({(int)mpkItem.StatusTrigger2Standard})");
                        }
                        if (jsonItem.KeepingType != mpkItem.KeepingType)
                        {
                            details.Add($"  FunctionStatus Mismatch: Json ({jsonItem.KeepingType}) vs MPK ({(int)mpkItem.KeepingType})");
                        }
                        if (jsonItem.ShotFxListType != mpkItem.ShotFxListType)
                        {
                            details.Add($"  ShotFxListType Mismatch: Json ({jsonItem.ShotFxListType}) vs MPK ({(int)mpkItem.ShotFxListType})");
                        }
                        if (jsonItem.FxTarget01 != mpkItem.FxTarget01)
                        {
                            details.Add($"  FxTarget Mismatch: Json ({jsonItem.FxTarget01}) vs MPK ({(int)mpkItem.FxTarget01})");
                        }
                        if (jsonItem.FxSocketPoint01 != mpkItem.FxSocketPoint01)
                        {
                            details.Add($"  SocketPoint Mismatch: Json ({jsonItem.FxSocketPoint01}) vs MPK ({(int)mpkItem.FxSocketPoint01})");
                        }
                        if (jsonItem.FxTarget02 != mpkItem.FxTarget02)
                        {
                            details.Add($"  FxTarget Mismatch: Json ({jsonItem.FxTarget02}) vs MPK ({(int)mpkItem.FxTarget02})");
                        }
                        if (jsonItem.FxSocketPoint02 != mpkItem.FxSocketPoint02)
                        {
                            details.Add($"  SocketPoint Mismatch: Json ({jsonItem.FxSocketPoint02}) vs MPK ({(int)mpkItem.FxSocketPoint02})");
                        }
                        if (jsonItem.FxTarget03 != mpkItem.FxTarget03)
                        {
                            details.Add($"  FxTarget Mismatch: Json ({jsonItem.FxTarget03}) vs MPK ({(int)mpkItem.FxTarget03})");
                        }
                        if (jsonItem.FxSocketPoint03 != mpkItem.FxSocketPoint03)
                        {
                            details.Add($"  SocketPoint Mismatch: Json ({jsonItem.FxSocketPoint03}) vs MPK ({(int)mpkItem.FxSocketPoint03})");
                        }
                        if (jsonItem.FxTargetFull != mpkItem.FxTargetFull)
                        {
                            details.Add($"  FxTarget Mismatch: Json ({jsonItem.FxTargetFull}) vs MPK ({(int)mpkItem.FxTargetFull})");
                        }
                        if (jsonItem.FxSocketPointFull != mpkItem.FxSocketPointFull)
                        {
                            details.Add($"  SocketPoint Mismatch: Json ({jsonItem.FxSocketPointFull}) vs MPK ({(int)mpkItem.FxSocketPointFull})");
                        }
                        if (jsonItem.FxTarget01Arena != mpkItem.FxTarget01Arena)
                        {
                            details.Add($"  FxTarget Mismatch: Json ({jsonItem.FxTarget01Arena}) vs MPK ({(int)mpkItem.FxTarget01Arena})");
                        }
                        if (jsonItem.FxSocketPoint01Arena != mpkItem.FxSocketPoint01Arena)
                        {
                            details.Add($"  SocketPoint Mismatch: Json ({jsonItem.FxSocketPoint01Arena}) vs MPK ({(int)mpkItem.FxSocketPoint01Arena})");
                        }
                        if (jsonItem.FxTarget02Arena != mpkItem.FxTarget02Arena)
                        {
                            details.Add($"  FxTarget Mismatch: Json ({jsonItem.FxTarget02Arena}) vs MPK ({(int)mpkItem.FxTarget02Arena})");
                        }
                        if (jsonItem.FxSocketPoint02Arena != mpkItem.FxSocketPoint02Arena)
                        {
                            details.Add($"  SocketPoint Mismatch: Json ({jsonItem.FxSocketPoint02Arena}) vs MPK ({(int)mpkItem.FxSocketPoint02Arena})");
                        }
                        if (jsonItem.FxTarget03Arena != mpkItem.FxTarget03Arena)
                        {
                            details.Add($"  FxTarget Mismatch: Json ({jsonItem.FxTarget03Arena}) vs MPK ({(int)mpkItem.FxTarget03Arena})");
                        }
                        if (jsonItem.FxSocketPoint03Arena != mpkItem.FxSocketPoint03Arena)
                        {
                            details.Add($"  SocketPoint Mismatch: Json ({jsonItem.FxSocketPoint03Arena}) vs MPK ({(int)mpkItem.FxSocketPoint03Arena})");
                        }
                    }
                },
                (jsonItem, mpkToJsonItem) =>
                {
                    return mpkToJsonItem != null && (
                        (jsonItem.StatusTriggerType == StatusTriggerType.IsAlive && mpkToJsonItem.StatusTriggerType == StatusTriggerType.IsAliveV2) ||
                        (jsonItem.StatusTrigger2Type == StatusTriggerType.IsAlive && mpkToJsonItem.StatusTrigger2Type == StatusTriggerType.IsAliveV2) ||
                        (jsonItem.FunctionType == FunctionType.ImmuneStun && mpkToJsonItem.FunctionType == FunctionType.ImmuneStunD) ||
                        (jsonItem.GroupId == 2142103) ||
                        (jsonItem.TimingTriggerType == TimingTriggerType.OnDead && mpkToJsonItem.TimingTriggerType == TimingTriggerType.OnDeadV2)
                    );
                },
                checkMpkItemDetails: (details, mpkItem) =>
                {
                    if (Enum.IsDefined(typeof(BuffType), (int)mpkItem.BuffType) == false)
                    {
                        details.Add($"  Unknown BuffType in MPK: {(int)mpkItem.BuffType}");
                    }
                    if (Enum.IsDefined(typeof(BuffRemoveType), (int)mpkItem.BuffRemoveType) == false)
                    {
                        details.Add($"  Unknown BuffRemoveType in MPK: {(int)mpkItem.BuffRemoveType}");
                    }
                    if (Enum.IsDefined(typeof(FunctionType), (int)mpkItem.FunctionType) == false)
                    {
                        details.Add($"  Unknown FunctionType in MPK: {(int)mpkItem.FunctionType}");
                    }
                    if (Enum.IsDefined(typeof(NikkeMpkConverter.model.ValueType), (int)mpkItem.FunctionValueType) == false)
                    {
                        details.Add($"  Unknown FunctionValueType in MPK: {(int)mpkItem.FunctionValueType}");
                    }
                    if (Enum.IsDefined(typeof(StandardType), (int)mpkItem.FunctionStandard) == false)
                    {
                        details.Add($"  Unknown StandardType in MPK: {(int)mpkItem.FunctionStandard}");
                    }
                    if (Enum.IsDefined(typeof(DurationType), (int)mpkItem.DelayType) == false)
                    {
                        details.Add($"  Unknown DurationType in MPK: {(int)mpkItem.DelayType}");
                    }
                    if (Enum.IsDefined(typeof(DurationType), (int)mpkItem.DurationType) == false)
                    {
                        details.Add($"  Unknown DurationType in MPK: {(int)mpkItem.DurationType}");
                    }
                    if (Enum.IsDefined(typeof(FunctionTargetType), (int)mpkItem.FunctionTarget) == false)
                    {
                        details.Add($"  Unknown FunctionTargetType in MPK: {(int)mpkItem.FunctionTarget}");
                    }
                    if (Enum.IsDefined(typeof(TimingTriggerType), (int)mpkItem.TimingTriggerType) == false)
                    {
                        details.Add($"  Unknown TimingTriggerType in MPK: {(int)mpkItem.TimingTriggerType}");
                    }
                    if (Enum.IsDefined(typeof(StandardType), (int)mpkItem.TimingTriggerStandard) == false)
                    {
                        details.Add($"  Unknown StandardType in MPK: {(int)mpkItem.TimingTriggerStandard}");
                    }
                    if (Enum.IsDefined(typeof(StatusTriggerType), (int)mpkItem.StatusTriggerType) == false)
                    {
                        details.Add($"  Unknown StatusTriggerType in MPK: {(int)mpkItem.StatusTriggerType}");
                    }
                    if (Enum.IsDefined(typeof(StandardType), (int)mpkItem.StatusTriggerStandard) == false)
                    {
                        details.Add($"  Unknown StandardType in MPK: {(int)mpkItem.StatusTriggerStandard}");
                    }
                    if (Enum.IsDefined(typeof(StatusTriggerType), (int)mpkItem.StatusTrigger2Type) == false)
                    {
                        details.Add($"  Unknown StatusTrigger2Type in MPK: {(int)mpkItem.StatusTrigger2Type}");
                    }
                    if (Enum.IsDefined(typeof(StandardType), (int)mpkItem.StatusTrigger2Standard) == false)
                    {
                        details.Add($"  Unknown StandardType in MPK: {(int)mpkItem.StatusTrigger2Standard}");
                    }
                    if (Enum.IsDefined(typeof(FunctionStatus), (int)mpkItem.KeepingType) == false)
                    {
                        details.Add($"  Unknown KeepingType in MPK: {(int)mpkItem.KeepingType}");
                    }
                    if (Enum.IsDefined(typeof(ShotFx), (int)mpkItem.ShotFxListType) == false)
                    {
                        details.Add($"  Unknown ShotFxListType in MPK: {(int)mpkItem.ShotFxListType}");
                    }
                    if (Enum.IsDefined(typeof(FxTarget), (int)mpkItem.FxTarget01) == false)
                    {
                        details.Add($"  Unknown FxTarget in MPK: {(int)mpkItem.FxTarget01}");
                    }
                    if (Enum.IsDefined(typeof(SocketPoint), (int)mpkItem.FxSocketPoint01) == false)
                    {
                        details.Add($"  Unknown FxSocketPoint in MPK: {(int)mpkItem.FxSocketPoint01}");
                    }
                    if (Enum.IsDefined(typeof(FxTarget), (int)mpkItem.FxTarget02) == false)
                    {
                        details.Add($"  Unknown FxTarget in MPK: {(int)mpkItem.FxTarget02}");
                    }
                    if (Enum.IsDefined(typeof(SocketPoint), (int)mpkItem.FxSocketPoint02) == false)
                    {
                        details.Add($"  Unknown FxSocketPoint in MPK: {(int)mpkItem.FxSocketPoint02}");
                    }
                    if (Enum.IsDefined(typeof(FxTarget), (int)mpkItem.FxTarget03) == false)
                    {
                        details.Add($"  Unknown FxTarget in MPK: {(int)mpkItem.FxTarget03}");
                    }
                    if (Enum.IsDefined(typeof(SocketPoint), (int)mpkItem.FxSocketPoint03) == false)
                    {
                        details.Add($"  Unknown FxSocketPoint in MPK: {(int)mpkItem.FxSocketPoint03}");
                    }
                    if (Enum.IsDefined(typeof(FxTarget), (int)mpkItem.FxTargetFull) == false)
                    {
                        details.Add($"  Unknown FxTarget in MPK: {(int)mpkItem.FxTargetFull}");
                    }
                    if (Enum.IsDefined(typeof(SocketPoint), (int)mpkItem.FxSocketPointFull) == false)
                    {
                        details.Add($"  Unknown FxSocketPoint in MPK: {(int)mpkItem.FxSocketPointFull}");
                    }
                    if (Enum.IsDefined(typeof(FxTarget), (int)mpkItem.FxTarget01Arena) == false)
                    {
                        details.Add($"  Unknown FxTarget in MPK: {(int)mpkItem.FxTarget01Arena}");
                    }
                    if (Enum.IsDefined(typeof(SocketPoint), (int)mpkItem.FxSocketPoint01Arena) == false)
                    {
                        details.Add($"  Unknown FxSocketPoint in MPK: {(int)mpkItem.FxSocketPoint01Arena}");
                    }
                    if (Enum.IsDefined(typeof(FxTarget), (int)mpkItem.FxTarget02Arena) == false)
                    {
                        details.Add($"  Unknown FxTarget in MPK: {(int)mpkItem.FxTarget02Arena}");
                    }
                    if (Enum.IsDefined(typeof(SocketPoint), (int)mpkItem.FxSocketPoint02Arena) == false)
                    {
                        details.Add($"  Unknown FxSocketPoint in MPK: {(int)mpkItem.FxSocketPoint02Arena}");
                    }
                    if (Enum.IsDefined(typeof(FxTarget), (int)mpkItem.FxTarget03Arena) == false)
                    {
                        details.Add($"  Unknown FxTarget in MPK: {(int)mpkItem.FxTarget03Arena}");
                    }
                    if (Enum.IsDefined(typeof(SocketPoint), (int)mpkItem.FxSocketPoint03Arena) == false)
                    {
                        details.Add($"  Unknown FxSocketPoint in MPK: {(int)mpkItem.FxSocketPoint03Arena}");
                    }

                }
            );

            await MpkConverter.ConvertTableAsync<InAppShopData>(
                inputPath + "InAppShopManagerTable" + inputExtension,
                outputPath + "InAppShopManagerTable" + outputExtension,
                (details, jsonItem, mpkItem) =>
                {
                    if (jsonItem.Id != mpkItem.Id)
                    {
                        details.Add($"ID Mismatch: Json {jsonItem.Id} vs MPK {mpkItem.Id}");
                    }
                    else
                    {
                        details.Add($"ID: {jsonItem.Id}");
                        if (jsonItem.MainCategoryType != mpkItem.MainCategoryType)
                        {
                            details.Add($"  MainCategoryType Mismatch: Json ({jsonItem.MainCategoryType}) vs MPK ({(int)mpkItem.MainCategoryType})");
                        }
                        if (jsonItem.RenewType != mpkItem.RenewType)
                        {
                            details.Add($"  RenewType Mismatch: Json ({jsonItem.RenewType}) vs MPK ({(int)mpkItem.RenewType})");
                        }
                        if (jsonItem.ShopType != mpkItem.ShopType)
                        {
                            details.Add($"  ShopType Mismatch: Json ({jsonItem.ShopType}) vs MPK ({(int)mpkItem.ShopType})");
                        }
                        if (jsonItem.ShopCategory != mpkItem.ShopCategory)
                        {
                            details.Add($"  ShopCategory Mismatch: Json ({jsonItem.ShopCategory}) vs MPK ({(int)mpkItem.ShopCategory})");
                        }
                    }
                },
                checkMpkItemDetails: (details, mpkItem) =>
                {
                    if (Enum.IsDefined(typeof(MainCategoryType), (int)mpkItem.MainCategoryType) == false)
                    {
                        details.Add($"  Unknown MainCategoryType in MPK: {(int)mpkItem.MainCategoryType}");
                    }
                    if (Enum.IsDefined(typeof(RenewType), (int)mpkItem.RenewType) == false)
                    {
                        details.Add($"  Unknown RenewType in MPK: {(int)mpkItem.RenewType}");
                    }
                    if (Enum.IsDefined(typeof(ShopCategory), (int)mpkItem.ShopCategory) == false)
                    {
                        details.Add($"  Unknown ShopCategory in MPK: {(int)mpkItem.ShopCategory}");
                    }
                    if (Enum.IsDefined(typeof(ShopType), (int)mpkItem.ShopType) == false)
                    {
                        details.Add($"  Unknown ShopType in MPK: {(int)mpkItem.ShopType}");
                    }
                }
            );
            
            await MpkConverter.ConvertTableAsync<ConsumeItemData>(
                inputPath + "ItemConsumeTable" + inputExtension,
                outputPath + "ItemConsumeTable" + outputExtension,
                (details, jsonItem, mpkItem) =>
                {
                    if (jsonItem.Id != mpkItem.Id)
                    {
                        details.Add($"ID Mismatch: Json {jsonItem.Id} vs MPK {mpkItem.Id}");
                    }
                    else
                    {
                        details.Add($"ID: {jsonItem.Id}");
                        if (jsonItem.UseConditionType != mpkItem.UseConditionType)
                        {
                            details.Add($"  UseConditionType Mismatch: Json ({jsonItem.UseConditionType}) vs MPK ({(int)mpkItem.UseConditionType})");
                        }
                        if (jsonItem.UseType != mpkItem.UseType)
                        {
                            details.Add($"  UseType Mismatch: Json ({jsonItem.UseType}) vs MPK ({(int)mpkItem.UseType})");
                        }
                        if (jsonItem.ItemType != mpkItem.ItemType)
                        {
                            details.Add($"  ItemType Mismatch: Json ({jsonItem.ItemType}) vs MPK ({(int)mpkItem.ItemType})");
                        }
                        if (jsonItem.ItemSubType != mpkItem.ItemSubType)
                        {
                            details.Add($"  ItemSubType Mismatch: Json ({jsonItem.ItemSubType}) vs MPK ({(int)mpkItem.ItemSubType})");
                        }
                        if (jsonItem.ItemRarity != mpkItem.ItemRarity)
                        {
                            details.Add($"  Rarity Mismatch: Json ({jsonItem.ItemRarity}) vs MPK ({(int)mpkItem.ItemRarity})");
                        }
                        if (jsonItem.PercentDisplayType != mpkItem.PercentDisplayType)
                        {
                            details.Add($"  PercentDisplayType Mismatch: Json ({jsonItem.PercentDisplayType}) vs MPK ({(int)mpkItem.PercentDisplayType})");
                        }
                    }
                },
                checkMpkItemDetails: (details, mpkItem) =>
                {
                    if (Enum.IsDefined(typeof(UseConditionType), (int)mpkItem.UseConditionType) == false)
                    {
                        details.Add($"  Unknown UseConditionType in MPK: {(int)mpkItem.UseConditionType}");
                    }
                    if (Enum.IsDefined(typeof(UseType), (int)mpkItem.UseType) == false)
                    {
                        details.Add($"  Unknown UseType in MPK: {(int)mpkItem.UseType}");
                    }
                    if (Enum.IsDefined(typeof(ItemType), (int)mpkItem.ItemType) == false)
                    {
                        details.Add($"  Unknown ItemType in MPK: {(int)mpkItem.ItemType}");
                    }
                    if (Enum.IsDefined(typeof(ItemSubType), (int)mpkItem.ItemSubType) == false)
                    {
                        details.Add($"  Unknown ItemSubType in MPK: {(int)mpkItem.ItemSubType}");
                    }
                    if (Enum.IsDefined(typeof(ItemRarity), (int)mpkItem.ItemRarity) == false)
                    {
                        details.Add($"  Unknown ItemRarity in MPK: {(int)mpkItem.ItemRarity}");
                    }
                    if (Enum.IsDefined(typeof(PercentDisplayType), (int)mpkItem.PercentDisplayType) == false)
                    {
                        details.Add($"  Unknown PercentDisplayType in MPK: {(int)mpkItem.PercentDisplayType}");
                    }
                },
                stopOnFirstMismatch: false
            );
        }
    }
}
