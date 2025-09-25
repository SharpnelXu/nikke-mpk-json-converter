using MemoryPack;
using System.Text.Json.Serialization;

namespace NikkeMpkConverter.model
{
    public enum ItemType
    {
        Unknown = -1,
        Equip = 1,
        HarmonyCube = 2
    }

    public enum ItemRarity
    {
        Unknown = -1,
        T1 = 1,
        T2 = 2,
        T3 = 3,
        T4 = 4,
        T5 = 5,
        T6 = 6,
        T7 = 7,
        T8 = 8,
        T9 = 9,
        T10 = 10
    }

    public enum ItemSubType
    {
        Unknown = -1,
        [JsonPropertyName("Module_A")]
        Head = 1,
        [JsonPropertyName("Module_B")]
        Body = 2,
        [JsonPropertyName("Module_C")]
        Arm = 3,
        [JsonPropertyName("Module_D")]
        Leg = 4
    }

    public enum StatType
    {
        Atk = 1,
        Defence = 2,
        Hp = 3,
        None = 0
    }

    public enum FavoriteItemType
    {
        Unknown = -1,
        Collection = 1,
        Favorite = 2
    }

    public enum ShopCategory
    {
        Unknown = -1,
        TimeLimitPackageShop = 1,
        CustomPackageShop = 2,
        StepUpPackageShop = 3,
        RenewPackageShop = 4,
        PassCostumeShop = 5,
        PopupPackageShop = 6,
        CostumeShop = 7,
        CampaignPackageShop = 8,
        MonthlyAmountShop = 9,
        JewelShop = 10
    }

    public enum ProductType
    {
        Unknown = -1,
        Item = 5,
        Currency = 3,
        CharacterCostume = 2
    }

    /// <summary>
    /// Equipment data from ItemEquipTable
    /// </summary>
    [MemoryPackable]
    public partial class EquipmentData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name_localkey")]
        public string NameLocalkey { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionLocalkey { get; set; } = string.Empty;

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("resource_id")]
        public string ResourceId { get; set; } = string.Empty;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("item_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemType ItemType { get; set; } = ItemType.Unknown;

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("item_sub_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemSubType ItemSubType { get; set; } = ItemSubType.Unknown;

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("class")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NikkeClass CharacterClass { get; set; } = NikkeClass.Unknown;

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("item_rare")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemRarity ItemRarity { get; set; } = ItemRarity.Unknown;

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("grade_core_id")]
        public int GradeCoreId { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("grow_grade")]
        public int GrowGrade { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("stat")]
        public EquipmentStat[] Stat { get; set; } = [];

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("option_slot")]
        public OptionSlot[] OptionSlots { get; set; } = [];

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("option_cost")]
        public int OptionCost { get; set; }

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("option_change_cost")]
        public int OptionChangeCost { get; set; }

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("option_lock_cost")]
        public int OptionLockCost { get; set; }
    }

    [MemoryPackable]
    public partial class EquipmentStat
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("stat_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatType StatType { get; set; } = StatType.None;

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("stat_value")]
        public int StatValue { get; set; }
    }

    [MemoryPackable]
    public partial class OptionSlot
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("option_slot")]
        public int OptionSlotValue { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("option_slot_success_ratio")]
        public int OptionSlotSuccessRatio { get; set; }
    }

    [MemoryPackable]
    public partial class HarmonyCubeSkillGroup
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("skill_group_id")]
        public int SkillGroupId { get; set; }
    }

    /// <summary>
    /// Harmony Cube data from ItemHarmonyCubeTable
    /// </summary>
    [MemoryPackable]
    public partial class HarmonyCubeData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name_localkey")]
        public string NameLocalkey { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionLocalkey { get; set; } = string.Empty;

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("location_localkey")]
        public string LocationLocalkey { get; set; } = string.Empty;

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("order")]
        public int Order { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("resource_id")]
        public int ResourceId { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("bg")]
        public string Bg { get; set; } = string.Empty;

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("bg_color")]
        public string BgColor { get; set; } = string.Empty;

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("item_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemType ItemType { get; set; } = ItemType.Unknown;

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("item_sub_type")]
        public ItemSubType ItemSubType { get; set; } = ItemSubType.Unknown;

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("item_rare")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemRarity ItemRare { get; set; } = ItemRarity.Unknown;

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("class")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NikkeClass CharacterClass { get; set; } = NikkeClass.Unknown;

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("level_enhance_id")]
        public int LevelEnhanceId { get; set; }

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("harmonycube_skill_group")]
        public HarmonyCubeSkillGroup[] HarmonyCubeSkillGroups { get; set; } = [];
    }

    [MemoryPackable]
    public partial class HarmonyCubeSkillLevel
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("skill_level")]
        public int Level { get; set; }
    }

    [MemoryPackable]
    public partial class HarmonyCubeStat
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("stat_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatType StatType { get; set; } = StatType.None;

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("stat_rate")]
        public int Rate { get; set; }
    }

    [MemoryPackable]
    public partial class HarmonyCubeLevelData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("level_enhance_id")]
        public int LevelEnhanceId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("skill_levels")]
        public HarmonyCubeSkillLevel[] SkillLevels { get; set; } = [];

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("material_id")]
        public int MaterialId { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("material_value")]
        public int MaterialValue { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("gold_value")]
        public int GoldValue { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("harmonycube_stats")]
        public HarmonyCubeStat[] Stats { get; set; } = [];
    }

    [MemoryPackable]
    public partial class CollectionItemSkillGroup
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("collection_skill_id")]
        public int SkillGroupId { get; set; }
    }

    [MemoryPackable]
    public partial class FavoriteItemSkillGroup
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("favorite_skill_id")]
        public int SkillId { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("skill_table")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SkillType SkillTable { get; set; } = SkillType.Unknown;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("skill_change_slot")]
        public int SkillChangeSlot { get; set; }
    }

    /// <summary>
    /// Favorite item data from FavoriteItemTable
    /// </summary>
    [MemoryPackable]
    public partial class FavoriteItemData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name_localkey")]
        public string NameLocalkey { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionLocalkey { get; set; } = string.Empty;

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("icon_resource_id")]
        public string IconResourceId { get; set; } = string.Empty;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("img_resource_id")]
        public string ImgResourceId { get; set; } = string.Empty;

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("prop_resource_id")]
        public string PropResourceId { get; set; } = string.Empty;

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("order")]
        public int Order { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("favorite_rare")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Rarity FavoriteRare { get; set; } = Rarity.Unknown;

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("favorite_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FavoriteItemType FavoriteType { get; set; } = FavoriteItemType.Unknown;

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("weapon_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeaponType WeaponType { get; set; } = WeaponType.None;

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("name_code")]
        public int NameCode { get; set; }

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("max_level")]
        public int MaxLevel { get; set; }

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("level_enhance_id")]
        public int LevelEnhanceId { get; set; }

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("probability_group")]
        public int ProbabilityGroup { get; set; }

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("collection_skill_group_data")]
        public CollectionItemSkillGroup[] CollectionSkills { get; set; } = [];

        [MemoryPackOrder(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("favoriteitem_skill_group_data")]
        public FavoriteItemSkillGroup[] FavoriteItemSkills { get; set; } = [];

        [MemoryPackOrder(16)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("albumcategory_id")]
        public int AlbumCategoryId { get; set; }
    }

    [MemoryPackable]
    public partial class FavoriteItemStat
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("stat_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatType StatType { get; set; } = StatType.None;

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("stat_value")]
        public int Value { get; set; }
    }

    [MemoryPackable]
    public partial class CollectionItemSkillLevel
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("collection_skill_level")]
        public int Level { get; set; }
    }

    [MemoryPackable]
    public partial class FavoriteItemLevelData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("level_enhance_id")]
        public int LevelEnhanceId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("grade")]
        public int Grade { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("favoriteitem_stat_data")]
        public FavoriteItemStat[] Stats { get; set; } = [];

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("collection_skill_level_data")]
        public CollectionItemSkillLevel[] SkillLevels { get; set; } = [];
    }

    /// <summary>
    /// Package list data from PackageListTable
    /// </summary>
    [MemoryPackable]
    public partial class PackageListData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("package_shop_id")]
        public int PackageShopId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("package_order")]
        public int PackageOrder { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("name_localkey")]
        public string NameKey { get; set; } = string.Empty;

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionKey { get; set; } = string.Empty;

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("product_resource_id")]
        public string ProductResourceId { get; set; } = string.Empty;

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("buy_limit_type")]
        public string BuyLimitType { get; set; } = "Account";

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("is_limit")]
        public bool IsLimited { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("buy_limit_count")]
        public int BuyLimitCount { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }
    }

    /// <summary>
    /// In-app shop data from InAppShopManagerTable
    /// </summary>
    [MemoryPackable]
    public partial class InAppShopData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("main_category_type")]
        public string MainCategoryType { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("order_group_id")]
        public int OrderGroupId { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("name_localkey")]
        public string NameKey { get; set; } = string.Empty;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionKey { get; set; } = string.Empty;

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("main_category_icon_name")]
        public string IconName { get; set; } = string.Empty;

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("sub_category_id")]
        public int SubCategoryId { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("sub_category_name_localkey")]
        public string SubCategoryNameKey { get; set; } = string.Empty;

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("package_shop_id")]
        public int PackageShopId { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("is_hide_if_not_valid")]
        public bool HideIfNotValid { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("renew_type")]
        public string RenewType { get; set; } = "NoRenew";

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("start_date")]
        public string? StartDate { get; set; }

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("end_date")]
        public string? EndDate { get; set; }

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("date_ui_control")]
        public bool DateUiControl { get; set; }

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("shop_type")]
        public string ShopType { get; set; } = string.Empty;

        [MemoryPackOrder(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("shop_category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ShopCategory ShopCategory { get; set; } = ShopCategory.Unknown;

        [MemoryPackOrder(16)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("shop_prefab_name")]
        public string ShopPrefabName { get; set; } = string.Empty;
    }

    [MemoryPackable]
    public partial class PackageProductData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("package_group_id")]
        public int PackageGroupId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("product_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductType ProductType { get; set; } = ProductType.Unknown;

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("product_value")]
        public int ProductValue { get; set; }
    }

    /// <summary>
    /// Currency data from CurrencyTable
    /// </summary>
    [MemoryPackable]
    public partial class CurrencyData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name_localkey")]
        public string NameKey { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionKey { get; set; } = string.Empty;

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("resource_id")]
        public int ResourceId { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("is_visible_to_inventory")]
        public bool IsVisibleInInventory { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("max_value")]
        public long MaxValue { get; set; }
    }

    [MemoryPackable]
    public partial class StepUpPackageData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("stepup_group_id")]
        public int StepUpGroupId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("package_group_id")]
        public int PackageGroupId { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("step")]
        public int Step { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("previous_package_id")]
        public int PreviousPackageId { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("is_last_step")]
        public bool IsLastStep { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("product_effieciency")]
        public double ProductEfficiency { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("buy_limit_type")]
        public string BuyLimitType { get; set; } = "Account";

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("is_limit")]
        public bool IsLimited { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("buy_limit_count")]
        public int BuyLimitCount { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("is_free")]
        public bool IsFree { get; set; }

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("midas_product_id")]
        public int MidasProductId { get; set; }

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("name_localkey")]
        public string NameKey { get; set; } = string.Empty;

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionKey { get; set; } = string.Empty;

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("product_resource_id")]
        public string ProductResourceId { get; set; } = string.Empty;
    }

    [MemoryPackable]
    public partial class CustomPackageShopData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("custom_shop_id")]
        public int CustomShopId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("custom_order")]
        public int CustomOrder { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("package_group_id")]
        public int PackageGroupId { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("custom_group_id")]
        public int CustomGroupId { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("custom_group_count")]
        public int CustomGroupCount { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("name_localkey")]
        public string NameKey { get; set; } = string.Empty;

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionKey { get; set; } = string.Empty;

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("product_resource_id")]
        public string ProductResourceId { get; set; } = string.Empty;

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("buy_limit_type")]
        public string BuyLimitType { get; set; } = "Account";

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("is_limit")]
        public bool IsLimited { get; set; }

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("buy_limit_count")]
        public int BuyLimitCount { get; set; }

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("is_free")]
        public bool IsFree { get; set; }

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("midas_product_id")]
        public int MidasProductId { get; set; }
    }

    [MemoryPackable]
    public partial class CustomPackageSlotData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("custom_group_id")]
        public int CustomGroupId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("slot_number")]
        public int SlotNumber { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("product_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductType ProductType { get; set; } = ProductType.Unknown;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("product_value")]
        public int ProductValue { get; set; }
    }

    [MemoryPackable]
    public partial class MidasProductData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("product_type")]
        public string ProductType { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("item_type")]
        public string ItemType { get; set; } = string.Empty;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("midas_product_id_proximabeta")]
        public string ProximaBetaProductId { get; set; } = string.Empty;

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("midas_product_id_gamamobi")]
        public string GamamobiProductId { get; set; } = string.Empty;

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("is_free")]
        public bool IsFree { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("cost")]
        public string Cost { get; set; } = "0";
    }
}