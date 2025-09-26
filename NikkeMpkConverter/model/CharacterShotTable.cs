using MemoryPack;
using System.Text.Json.Serialization;

namespace NikkeMpkConverter.model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WeaponType
    {
        None = 0,
        AR = 1,
        RL = 2,
        SR = 3,
        MG = 4,
        SG = 5,
        GL = 7,
        SMG = 9,
        UNKNOWN = -1
    }

    public enum AttackType
    {
        None = 0,
        Energy = 1,
        Bio = 3,
        Metal = 2,
        Fire = 4,
        Water = 5,
        Wind = 6,
        Iron = 7,
        Electronic = 8,
        Unknown = -1
    }

    public enum CounterType
    {
        None = 0,
        Energy_Type = 2,
        Bio_Type = 3,
        Metal_Type = 1,
        Fire_Type = 10,
        Water_Type = 11,
        Wind_Type = 12,
        Iron_Type = 13,
        Electric_Type = 14,
        Unknown = -1
    }

    public enum PreferTarget
    {
        None = 0,

        Random = 31,
        HaveDebuff = 51,
        NotStun = 46,
        Front = 7,
        Back = 8,
        LongInitChargeTime = 54,

        HighAttack = 17,
        HighAttackFirstSelf = 37,
        HighAttackLastSelf = 23,
        HighDefence = 15,
        HighMaxHP = 13,
        HighHP = 12,
        LowDefence = 14,
        LowHP = 11,
        LowHPCover = 47,
        LowHPLastSelf = 18,
        LowHPRatio = 48,
        NearAim = 53,

        Attacker = 1,
        Defender = 2,
        Supporter = 3,

        Fire = 41,
        Water = 42,
        Electronic = 44,
        Iron = 43,
        Wind = 45,
        TargetAR = 25,
        TargetGL = 28,
        TargetPS = 29,
        Unknown = -1
    }

    public enum PreferTargetCondition
    {
        Unknown = -1,
        None = 0,
        ExcludeSelf = 1,
        DestroyCover = 2,
        IncludeNoneTargetLast = 3,
        IncludeNoneTargetNone = 4,
        OnlySG = 5,
        OnlyAR = 6,
        OnlyRL = 10
    }
    
    public enum ShotTiming
    {
        Sequence = 2,
        Concurrence = 1,
        ConcurrenceGroup = 3,
        None = 0,
        Unknown = -1
    }

    public enum FireType
    {
        None = 0,
        Instant = 1, // All AR, SG, SR, MG (except Modernia burst)
        ProjectileCurve = 2, // Cindy
        ProjectileDirect = 3, // 5 RL occurrences (Laplace, Ynui Alt, Summer Neon burst, A2, SBS)
        HomingProjectile = 4, // should be all other RLs
        MultiTarget = 5, // Modernia burst
        Suicide = 7,
        Calling = 8,
        InstantAll = 9,
        InstantNumber = 10,
        ObjectCreate = 11,
        Barrier = 13,

        Range = 14,
        NormalCalling = 15,
        InstantAll_FrontRay = 16,
        StickyProjectileDirect = 17, // Rapi: Red Hood alt attack
        ObjectCreateToDecoy = 18,
        MechaShiftyShot = 19,
        ProjectileCurveV2 = 20,
        Unknown = -1
    }

    public enum InputType
    {
        DOWN = 1,
        DOWN_Charge = 3,
        UP = 2,
        None = 0,
    }

    public enum ShakeType
    {
        Fire_AR = 0,
        Fire_MG,
        Fire_SMG,
        Fire_RL = 3,
        Fire_SG = 4,
        Fire_SR,
        None
    }

    /// <summary>
    /// Represents a record in the CharacterShotTable
    /// </summary>
    [MemoryPackable]
    public partial class CharacterShotTable
    {
        /// <summary>
        /// Unique identifier for the character shot
        /// </summary>
        [MemoryPackOrder(0)]
		[JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Localization key for the shot name
        /// </summary>
        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name_localkey")]
        public string? NameLocalkey { get; set; } = string.Empty;
        /// <summary>
        /// Localization key for the shot description
        /// </summary>
        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
		[JsonPropertyName("description_localkey")]
        public string? DescriptionLocalkey { get; set; } = string.Empty;

        /// <summary>
        /// Camera work identifier
        /// </summary>
        [MemoryPackOrder(3)]
		[JsonPropertyOrder(3)]
        [JsonPropertyName("camera_work")]
        public string CameraWork { get; set; } = string.Empty;

        /// <summary>
        /// Weapon type (AR, SG, RL, SMG, etc.)
        /// </summary>
        [MemoryPackOrder(4)]
		[JsonPropertyOrder(4)]
        [JsonPropertyName("weapon_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeaponType WeaponType { get; set; }

        /// <summary>
        /// Attack type (Energy, Bio, Metal)
        /// </summary>
        [MemoryPackOrder(6)]
		[JsonPropertyOrder(5)]
        [JsonPropertyName("attack_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttackType AttackType { get; set; } = AttackType.None;

        /// <summary>
        /// Counter enemy type
        /// </summary>
        [MemoryPackOrder(7)]
		[JsonPropertyOrder(6)]
        [JsonPropertyName("counter_enermy")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CounterType CounterEnermy { get; set; } = CounterType.None;

        /// <summary>
        /// Preferred target type
        /// </summary>
        [MemoryPackOrder(10)]
		[JsonPropertyOrder(7)]
        [JsonPropertyName("prefer_target")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PreferTarget PreferTarget { get; set; } = PreferTarget.None;

        /// <summary>
        /// Preferred target condition
        /// </summary>
        [MemoryPackOrder(11)]
		[JsonPropertyOrder(8)]
        [JsonPropertyName("prefer_target_condition")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PreferTargetCondition PreferTargetCondition { get; set; } = PreferTargetCondition.None;

        /// <summary>
        /// Shot timing
        /// </summary>
        [MemoryPackOrder(17)]
		[JsonPropertyOrder(9)]
        [JsonPropertyName("shot_timing")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ShotTiming ShotTiming { get; set; } = ShotTiming.Unknown;

        /// <summary>
        /// Fire type (Instant, HomingProjectile, etc.)
        /// </summary>
        [MemoryPackOrder(5)]
		[JsonPropertyOrder(10)]
        [JsonPropertyName("fire_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FireType FireType { get; set; } = FireType.None;

        /// <summary>
        /// Input type (DOWN, UP)
        /// </summary>
        [MemoryPackOrder(8)]
		[JsonPropertyOrder(11)]
        [JsonPropertyName("input_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InputType InputType { get; set; } = InputType.None;

        /// <summary>
        /// Whether targeting is enabled
        /// </summary>
        [MemoryPackOrder(9)]
		[JsonPropertyOrder(12)]
        [JsonPropertyName("is_targeting")]
        public bool IsTargeting { get; set; }

        /// <summary>
        /// Base damage value
        /// </summary>
        [MemoryPackOrder(12)]
		[JsonPropertyOrder(13)]
        [JsonPropertyName("damage")]
        public int Damage { get; set; }

        /// <summary>
        /// Number of shots per fire
        /// </summary>
        [MemoryPackOrder(13)]
		[JsonPropertyOrder(14)]
        [JsonPropertyName("shot_count")]
        public int ShotCount { get; set; }

        /// <summary>
        /// Number of muzzles
        /// </summary>
        [MemoryPackOrder(14)]
		[JsonPropertyOrder(15)]
        [JsonPropertyName("muzzle_count")]
        public int MuzzleCount { get; set; }

        /// <summary>
        /// Multi-target count
        /// </summary>
        [MemoryPackOrder(15)]
		[JsonPropertyOrder(16)]
        [JsonPropertyName("multi_target_count")]
        public int MultiTargetCount { get; set; }

        /// <summary>
        /// Center shot count
        /// </summary>
        [MemoryPackOrder(16)]
		[JsonPropertyOrder(17)]
        [JsonPropertyName("center_shot_count")]
        public int CenterShotCount { get; set; }

        /// <summary>
        /// Maximum ammunition count
        /// </summary>
        [MemoryPackOrder(18)]
		[JsonPropertyOrder(18)]
        [JsonPropertyName("max_ammo")]
        public int MaxAmmo { get; set; }

        /// <summary>
        /// Maintain fire stance time
        /// </summary>
        [MemoryPackOrder(19)]
		[JsonPropertyOrder(19)]
        [JsonPropertyName("maintain_fire_stance")]
        public int MaintainFireStance { get; set; }

        /// <summary>
        /// Up-type fire timing
        /// </summary>
        [MemoryPackOrder(20)]
		[JsonPropertyOrder(20)]
        [JsonPropertyName("uptype_fire_timing")]
        public int UptypeFireTiming { get; set; }

        /// <summary>
        /// Reload time in frames
        /// </summary>
        [MemoryPackOrder(21)]
		[JsonPropertyOrder(21)]
        [JsonPropertyName("reload_time")]
        public int ReloadTime { get; set; }

        /// <summary>
        /// Reload bullet count
        /// </summary>
        [MemoryPackOrder(22)]
		[JsonPropertyOrder(22)]
        [JsonPropertyName("reload_bullet")]
        public int ReloadBullet { get; set; }

        /// <summary>
        /// Ammo count when reload starts
        /// </summary>
        [MemoryPackOrder(23)]
		[JsonPropertyOrder(23)]
        [JsonPropertyName("reload_start_ammo")]
        public int ReloadStartAmmo { get; set; }

        /// <summary>
        /// Rate of fire reset time
        /// </summary>
        [MemoryPackOrder(24)]
		[JsonPropertyOrder(24)]
        [JsonPropertyName("rate_of_fire_reset_time")]
        public int RateOfFireResetTime { get; set; }

        /// <summary>
        /// Rate of fire (rounds per minute)
        /// </summary>
        [MemoryPackOrder(25)]
		[JsonPropertyOrder(25)]
        [JsonPropertyName("rate_of_fire")]
        public int RateOfFire { get; set; }

        /// <summary>
        /// End rate of fire
        /// </summary>
        [MemoryPackOrder(26)]
		[JsonPropertyOrder(26)]
        [JsonPropertyName("end_rate_of_fire")]
        public int EndRateOfFire { get; set; }

        /// <summary>
        /// Rate of fire change per shot
        /// </summary>
        [MemoryPackOrder(27)]
		[JsonPropertyOrder(27)]
        [JsonPropertyName("rate_of_fire_change_pershot")]
        public int RateOfFireChangePershot { get; set; }

        /// <summary>
        /// Burst energy per shot
        /// </summary>
        [MemoryPackOrder(28)]
		[JsonPropertyOrder(28)]
        [JsonPropertyName("burst_energy_pershot")]
        public int BurstEnergyPershot { get; set; }

        /// <summary>
        /// Target burst energy per shot
        /// </summary>
        [MemoryPackOrder(29)]
		[JsonPropertyOrder(29)]
        [JsonPropertyName("target_burst_energy_pershot")]
        public int TargetBurstEnergyPershot { get; set; }

        /// <summary>
        /// Spot first delay
        /// </summary>
        [MemoryPackOrder(31)]
		[JsonPropertyOrder(30)]
        [JsonPropertyName("spot_first_delay")]
        public int SpotFirstDelay { get; set; }

        /// <summary>
        /// Spot last delay
        /// </summary>
        [MemoryPackOrder(32)]
		[JsonPropertyOrder(31)]
        [JsonPropertyName("spot_last_delay")]
        public int SpotLastDelay { get; set; }

        /// <summary>
        /// Starting accuracy circle scale
        /// </summary>
        [MemoryPackOrder(33)]
		[JsonPropertyOrder(32)]
        [JsonPropertyName("start_accuracy_circle_scale")]
        public int StartAccuracyCircleScale { get; set; }

        /// <summary>
        /// End accuracy circle scale
        /// </summary>
        [MemoryPackOrder(34)]
		[JsonPropertyOrder(33)]
        [JsonPropertyName("end_accuracy_circle_scale")]
        public int EndAccuracyCircleScale { get; set; }

        /// <summary>
        /// Accuracy change per shot
        /// </summary>
        [MemoryPackOrder(35)]
		[JsonPropertyOrder(34)]
        [JsonPropertyName("accuracy_change_pershot")]
        public int AccuracyChangePershot { get; set; }

        /// <summary>
        /// Accuracy change speed
        /// </summary>
        [MemoryPackOrder(36)]
		[JsonPropertyOrder(35)]
        [JsonPropertyName("accuracy_change_speed")]
        public int AccuracyChangeSpeed { get; set; }

        /// <summary>
        /// Auto start accuracy circle scale
        /// </summary>
        [MemoryPackOrder(37)]
		[JsonPropertyOrder(36)]
        [JsonPropertyName("auto_start_accuracy_circle_scale")]
        public int AutoStartAccuracyCircleScale { get; set; }

        /// <summary>
        /// Auto end accuracy circle scale
        /// </summary>
        [MemoryPackOrder(38)]
		[JsonPropertyOrder(37)]
        [JsonPropertyName("auto_end_accuracy_circle_scale")]
        public int AutoEndAccuracyCircleScale { get; set; }

        /// <summary>
        /// Auto accuracy change per shot
        /// </summary>
        [MemoryPackOrder(39)]
		[JsonPropertyOrder(38)]
        [JsonPropertyName("auto_accuracy_change_pershot")]
        public int AutoAccuracyChangePershot { get; set; }

        /// <summary>
        /// Auto accuracy change speed
        /// </summary>
        [MemoryPackOrder(40)]
		[JsonPropertyOrder(39)]
        [JsonPropertyName("auto_accuracy_change_speed")]
        public int AutoAccuracyChangeSpeed { get; set; }

        /// <summary>
        /// Zoom rate
        /// </summary>
        [MemoryPackOrder(41)]
		[JsonPropertyOrder(40)]
        [JsonPropertyName("zoom_rate")]
        public int ZoomRate { get; set; }

        /// <summary>
        /// Multi-aim range
        /// </summary>
        [MemoryPackOrder(42)]
		[JsonPropertyOrder(41)]
        [JsonPropertyName("multi_aim_range")]
        public int MultiAimRange { get; set; }

        /// <summary>
        /// Spot projectile speed
        /// </summary>
        [MemoryPackOrder(43)]
		[JsonPropertyOrder(42)]
        [JsonPropertyName("spot_projectile_speed")]
        public int SpotProjectileSpeed { get; set; }

        /// <summary>
        /// Charge time in frames
        /// </summary>
        [MemoryPackOrder(44)]
		[JsonPropertyOrder(43)]
        [JsonPropertyName("charge_time")]
        public int ChargeTime { get; set; }

        /// <summary>
        /// Full charge damage multiplier
        /// </summary>
        [MemoryPackOrder(45)]
		[JsonPropertyOrder(44)]
        [JsonPropertyName("full_charge_damage")]
        public int FullChargeDamage { get; set; }

        /// <summary>
        /// Full charge burst energy
        /// </summary>
        [MemoryPackOrder(46)]
		[JsonPropertyOrder(45)]
        [JsonPropertyName("full_charge_burst_energy")]
        public int FullChargeBurstEnergy { get; set; }

        /// <summary>
        /// Spot radius object count
        /// </summary>
        [MemoryPackOrder(47)]
		[JsonPropertyOrder(46)]
        [JsonPropertyName("spot_radius_object")]
        public int SpotRadiusObject { get; set; }

        /// <summary>
        /// Spot radius
        /// </summary>
        [MemoryPackOrder(48)]
		[JsonPropertyOrder(47)]
        [JsonPropertyName("spot_radius")]
        public int SpotRadius { get; set; }

        /// <summary>
        /// Spot explosion range
        /// </summary>
        [MemoryPackOrder(49)]
		[JsonPropertyOrder(48)]
        [JsonPropertyName("spot_explosion_range")]
        public int SpotExplosionRange { get; set; }

        /// <summary>
        /// Homing script level (optional field, appears only for certain weapon types)
        /// </summary>
        [MemoryPackOrder(50)]
		[JsonPropertyOrder(49)]
        [JsonPropertyName("homing_script")]
        public string? HomingScript { get; set; } = string.Empty;

        /// <summary>
        /// Core damage rate multiplier
        /// </summary>
        [MemoryPackOrder(51)]
		[JsonPropertyOrder(50)]
        [JsonPropertyName("core_damage_rate")]
        public int CoreDamageRate { get; set; }

        /// <summary>
        /// Penetration value
        /// </summary>
        [MemoryPackOrder(30)]
		[JsonPropertyOrder(51)]
        [JsonPropertyName("penetration")]
        public int Penetration { get; set; }

        /// <summary>
        /// List of function IDs to use
        /// </summary>
        [MemoryPackOrder(52)]
		[JsonPropertyOrder(52)]
        [JsonPropertyName("use_function_id_list")]
        public int[] UseFunctionIdList { get; set; } = [];

        /// <summary>
        /// List of hurt function IDs
        /// </summary>
        [MemoryPackOrder(53)]
		[JsonPropertyOrder(53)]
        [JsonPropertyName("hurt_function_id_list")]
        public int[] HurtFunctionIdList { get; set; } = [];

        /// <summary>
        /// Shake effect ID
        /// </summary>
        [MemoryPackOrder(54)]
		[JsonPropertyOrder(54)]
        [JsonPropertyName("shake_id")]
        public int ShakeId { get; set; }

        /// <summary>
        /// Shake type identifier
        /// </summary>
        [MemoryPackOrder(55)]
		[JsonPropertyOrder(55)]
        [JsonPropertyName("ShakeType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ShakeType ShakeType { get; set; } = ShakeType.None;

        /// <summary>
        /// Shake weight/intensity
        /// </summary>
        [MemoryPackOrder(56)]
		[JsonPropertyOrder(56)]
        [JsonPropertyName("ShakeWeight")]
        public int ShakeWeight { get; set; }

        /// <summary>
        /// Aim prefab (optional field, appears only for certain weapon types)
        /// </summary>
        [MemoryPackOrder(57)]
		[JsonPropertyOrder(57)]
        [JsonPropertyName("aim_prefab")]
        public string? AimPrefab { get; set; } = string.Empty;
    }
}