using MemoryPack;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NikkeMpkConverter.model
{
    public enum WeaponType
    {
        None = 0,
        AR = 1,
        SG = 5,
        RL = 2,
        SMG = 9,
        MG = 4,
        SR = 3,
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
        Electric = 8,
        Unknown = -1
    }

    public enum CounterType
    {
        None = 0,
        Energy_Type = 1,
        Bio_Type = 2,
        Metal_Type = 3,
        Fire_Type = 4,
        Water_Type = 5,
        Wind_Type = 6,
        Iron_Type = 7,
        Electric_Type = 8,
        Unknown = -1
    }

    public enum PreferTarget
    {
        None = 0,
        TargetGL,
        TargetPS,

        Random,
        Back,
        HaveDebuff,
        NotStun,
        Front = 7,
        LongInitChargeTime,

        HighAttack,
        HighAttackFirstSelf,
        HighAttackLastSelf,
        HighDefence,
        HighHP,
        HighMaxHP,
        LowDefence,
        LowHP,
        LowHPCover,
        LowHPLastSelf,
        LowHPRatio,
        NearAim,

        Attacker,
        Defender,
        Supporter,

        Fire,
        TargetAR = 25,
        Water,
        Electronic,
        Iron,
        Wind,
        Unknown = -1
    }

    public enum PreferTargetCondition
    {
        Unknown = 0,
        None = 1,
        IncludeNoneTargetLast,
        IncludeNoneTargetNone,
        ExcludeSelf,
        DestroyCover,
        OnlyAR,
        OnlySG,
        OnlyRL
    }
    
    public enum ShotTiming
    {
        Sequence = 0,
        Concurrence = 1,
        Unknown = -1
    }

    public enum FireType
    {
        None = 0,
        HomingProjectile, // should be all other RLs
        Instant = 2, // All AR, SG, SR, MG (except Modernia burst)
        MechaShiftyShot,
        MultiTarget, // Modernia burst
        ProjectileCurve, // Cindy
        ProjectileDirect, // 5 RL occurrences (Laplace, Ynui Alt, Summer Neon burst, A2, SBS)
        StickyProjectileDirect, // Rapi: Red Hood alt attack

        Range,
        InstantAll,
        Suicide,
        Calling,
        Barrier,
        NormalCalling,
        InstantAll_FrontRay,
        ObjectCreate,
        ObjectCreateToDecoy,
        InstantNumber,
        ProjectileCurveV2,
        Unknown = -1
    }

    public enum InputType
    {
        DOWN = 0,
        DOWN_Charge,
        UP,
        None,
    }

    public enum ShakeType
    {
        Fire_AR = 0,
        Fire_RL,
        Fire_MG,
        Fire_SMG,
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
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Localization key for the shot name
        /// </summary>
        [MemoryPackOrder(1)]
        [JsonPropertyName("name_localkey")]
        public string NameLocalkey { get; set; } = string.Empty;

        /// <summary>
        /// Localization key for the shot description
        /// </summary>
        [MemoryPackOrder(2)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionLocalkey { get; set; } = string.Empty;

        /// <summary>
        /// Camera work identifier
        /// </summary>
        [MemoryPackOrder(3)]
        [JsonPropertyName("camera_work")]
        public string CameraWork { get; set; } = string.Empty;

        /// <summary>
        /// Weapon type (AR, SG, RL, SMG, etc.)
        /// </summary>
        [MemoryPackOrder(4)]
        [JsonPropertyName("weapon_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeaponType WeaponType { get; set; }

        /// <summary>
        /// Attack type (Energy, Bio, Metal)
        /// </summary>
        [MemoryPackOrder(6)]
        [JsonPropertyName("attack_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttackType AttackType { get; set; } = AttackType.None;

        /// <summary>
        /// Counter enemy type
        /// </summary>
        [MemoryPackOrder(5)]
        [JsonPropertyName("counter_enermy")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CounterType CounterEnermy { get; set; } = CounterType.None;

        /// <summary>
        /// Preferred target type
        /// </summary>
        [MemoryPackOrder(10)]
        [JsonPropertyName("prefer_target")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PreferTarget PreferTarget { get; set; } = PreferTarget.None;

        /// <summary>
        /// Preferred target condition
        /// </summary>
        [MemoryPackOrder(8)]
        [JsonPropertyName("prefer_target_condition")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PreferTargetCondition PreferTargetCondition { get; set; } = PreferTargetCondition.None;

        /// <summary>
        /// Whether targeting is enabled
        /// </summary>
        [MemoryPackOrder(9)]
        [JsonPropertyName("is_targeting")]
        public bool IsTargeting { get; set; }

        /// <summary>
        /// Fire type (Instant, HomingProjectile, etc.)
        /// </summary>
        [MemoryPackOrder(7)]
        [JsonPropertyName("fire_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FireType FireType { get; set; } = FireType.None;

        /// <summary>
        /// Input type (DOWN, UP)
        /// </summary>
        [MemoryPackOrder(11)]
        [JsonPropertyName("input_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InputType InputType { get; set; } = InputType.None;

        /// <summary>
        /// Base damage value
        /// </summary>
        [MemoryPackOrder(12)]
        [JsonPropertyName("damage")]
        public int Damage { get; set; }

        /// <summary>
        /// Number of shots per fire
        /// </summary>
        [MemoryPackOrder(13)]
        [JsonPropertyName("shot_count")]
        public int ShotCount { get; set; }

        /// <summary>
        /// Number of muzzles
        /// </summary>
        [MemoryPackOrder(14)]
        [JsonPropertyName("muzzle_count")]
        public int MuzzleCount { get; set; }

        /// <summary>
        /// Multi-target count
        /// </summary>
        [MemoryPackOrder(15)]
        [JsonPropertyName("multi_target_count")]
        public int MultiTargetCount { get; set; }

        /// <summary>
        /// Center shot count
        /// </summary>
        [MemoryPackOrder(16)]
        [JsonPropertyName("center_shot_count")]
        public int CenterShotCount { get; set; }

        /// <summary>
        /// Shot timing
        /// </summary>
        [MemoryPackOrder(17)]
        [JsonPropertyName("shot_timing")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ShotTiming ShotTiming { get; set; } = ShotTiming.Unknown;

        /// <summary>
        /// Maximum ammunition count
        /// </summary>
        [MemoryPackOrder(18)]
        [JsonPropertyName("max_ammo")]
        public int MaxAmmo { get; set; }

        /// <summary>
        /// Maintain fire stance time
        /// </summary>
        [MemoryPackOrder(19)]
        [JsonPropertyName("maintain_fire_stance")]
        public int MaintainFireStance { get; set; }

        /// <summary>
        /// Up-type fire timing
        /// </summary>
        [MemoryPackOrder(20)]
        [JsonPropertyName("uptype_fire_timing")]
        public int UptypeFireTiming { get; set; }

        /// <summary>
        /// Reload time in frames
        /// </summary>
        [MemoryPackOrder(21)]
        [JsonPropertyName("reload_time")]
        public int ReloadTime { get; set; }

        /// <summary>
        /// Reload bullet count
        /// </summary>
        [MemoryPackOrder(22)]
        [JsonPropertyName("reload_bullet")]
        public int ReloadBullet { get; set; }

        /// <summary>
        /// Ammo count when reload starts
        /// </summary>
        [MemoryPackOrder(23)]
        [JsonPropertyName("reload_start_ammo")]
        public int ReloadStartAmmo { get; set; }

        /// <summary>
        /// Rate of fire reset time
        /// </summary>
        [MemoryPackOrder(24)]
        [JsonPropertyName("rate_of_fire_reset_time")]
        public int RateOfFireResetTime { get; set; }

        /// <summary>
        /// Rate of fire (rounds per minute)
        /// </summary>
        [MemoryPackOrder(25)]
        [JsonPropertyName("rate_of_fire")]
        public int RateOfFire { get; set; }

        /// <summary>
        /// End rate of fire
        /// </summary>
        [MemoryPackOrder(26)]
        [JsonPropertyName("end_rate_of_fire")]
        public int EndRateOfFire { get; set; }

        /// <summary>
        /// Rate of fire change per shot
        /// </summary>
        [MemoryPackOrder(27)]
        [JsonPropertyName("rate_of_fire_change_pershot")]
        public int RateOfFireChangePershot { get; set; }

        /// <summary>
        /// Burst energy per shot
        /// </summary>
        [MemoryPackOrder(28)]
        [JsonPropertyName("burst_energy_pershot")]
        public int BurstEnergyPershot { get; set; }

        /// <summary>
        /// Target burst energy per shot
        /// </summary>
        [MemoryPackOrder(29)]
        [JsonPropertyName("target_burst_energy_pershot")]
        public int TargetBurstEnergyPershot { get; set; }

        /// <summary>
        /// Penetration value
        /// </summary>
        [MemoryPackOrder(30)]
        [JsonPropertyName("penetration")]
        public int Penetration { get; set; }

        /// <summary>
        /// Spot first delay
        /// </summary>
        [MemoryPackOrder(31)]
        [JsonPropertyName("spot_first_delay")]
        public int SpotFirstDelay { get; set; }

        /// <summary>
        /// Spot last delay
        /// </summary>
        [MemoryPackOrder(32)]
        [JsonPropertyName("spot_last_delay")]
        public int SpotLastDelay { get; set; }

        /// <summary>
        /// Starting accuracy circle scale
        /// </summary>
        [MemoryPackOrder(33)]
        [JsonPropertyName("start_accuracy_circle_scale")]
        public int StartAccuracyCircleScale { get; set; }

        /// <summary>
        /// End accuracy circle scale
        /// </summary>
        [MemoryPackOrder(34)]
        [JsonPropertyName("end_accuracy_circle_scale")]
        public int EndAccuracyCircleScale { get; set; }

        /// <summary>
        /// Accuracy change per shot
        /// </summary>
        [MemoryPackOrder(35)]
        [JsonPropertyName("accuracy_change_pershot")]
        public int AccuracyChangePershot { get; set; }

        /// <summary>
        /// Accuracy change speed
        /// </summary>
        [MemoryPackOrder(36)]
        [JsonPropertyName("accuracy_change_speed")]
        public int AccuracyChangeSpeed { get; set; }

        /// <summary>
        /// Auto start accuracy circle scale
        /// </summary>
        [MemoryPackOrder(37)]
        [JsonPropertyName("auto_start_accuracy_circle_scale")]
        public int AutoStartAccuracyCircleScale { get; set; }

        /// <summary>
        /// Auto end accuracy circle scale
        /// </summary>
        [MemoryPackOrder(38)]
        [JsonPropertyName("auto_end_accuracy_circle_scale")]
        public int AutoEndAccuracyCircleScale { get; set; }

        /// <summary>
        /// Auto accuracy change per shot
        /// </summary>
        [MemoryPackOrder(39)]
        [JsonPropertyName("auto_accuracy_change_pershot")]
        public int AutoAccuracyChangePershot { get; set; }

        /// <summary>
        /// Auto accuracy change speed
        /// </summary>
        [MemoryPackOrder(40)]
        [JsonPropertyName("auto_accuracy_change_speed")]
        public int AutoAccuracyChangeSpeed { get; set; }

        /// <summary>
        /// Zoom rate
        /// </summary>
        [MemoryPackOrder(41)]
        [JsonPropertyName("zoom_rate")]
        public int ZoomRate { get; set; }

        /// <summary>
        /// Multi-aim range
        /// </summary>
        [MemoryPackOrder(42)]
        [JsonPropertyName("multi_aim_range")]
        public int MultiAimRange { get; set; }

        /// <summary>
        /// Spot projectile speed
        /// </summary>
        [MemoryPackOrder(43)]
        [JsonPropertyName("spot_projectile_speed")]
        public int SpotProjectileSpeed { get; set; }

        /// <summary>
        /// Charge time in frames
        /// </summary>
        [MemoryPackOrder(44)]
        [JsonPropertyName("charge_time")]
        public int ChargeTime { get; set; }

        /// <summary>
        /// Full charge damage multiplier
        /// </summary>
        [MemoryPackOrder(45)]
        [JsonPropertyName("full_charge_damage")]
        public int FullChargeDamage { get; set; }

        /// <summary>
        /// Full charge burst energy
        /// </summary>
        [MemoryPackOrder(46)]
        [JsonPropertyName("full_charge_burst_energy")]
        public int FullChargeBurstEnergy { get; set; }

        /// <summary>
        /// Spot radius object count
        /// </summary>
        [MemoryPackOrder(47)]
        [JsonPropertyName("spot_radius_object")]
        public int SpotRadiusObject { get; set; }

        /// <summary>
        /// Spot radius
        /// </summary>
        [MemoryPackOrder(48)]
        [JsonPropertyName("spot_radius")]
        public int SpotRadius { get; set; }

        /// <summary>
        /// Spot explosion range
        /// </summary>
        [MemoryPackOrder(49)]
        [JsonPropertyName("spot_explosion_range")]
        public int SpotExplosionRange { get; set; }

        /// <summary>
        /// Homing script level (optional field, appears only for certain weapon types)
        /// </summary>
        [MemoryPackOrder(50)]
        [JsonPropertyName("homing_script")]
        public string? HomingScript { get; set; } = String.Empty;

        /// <summary>
        /// Core damage rate multiplier
        /// </summary>
        [MemoryPackOrder(51)]
        [JsonPropertyName("core_damage_rate")]
        public int CoreDamageRate { get; set; }

        /// <summary>
        /// List of function IDs to use
        /// </summary>
        [MemoryPackOrder(52)]
        [JsonPropertyName("use_function_id_list")]
        public int[] UseFunctionIdList { get; set; } = [];

        /// <summary>
        /// List of hurt function IDs
        /// </summary>
        [MemoryPackOrder(53)]
        [JsonPropertyName("hurt_function_id_list")]
        public int[] HurtFunctionIdList { get; set; } = [];

        /// <summary>
        /// Shake effect ID
        /// </summary>
        [MemoryPackOrder(54)]
        [JsonPropertyName("shake_id")]
        public int ShakeId { get; set; }

        /// <summary>
        /// Shake type identifier
        /// </summary>
        [MemoryPackOrder(55)]
        [JsonPropertyName("ShakeType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ShakeType ShakeType { get; set; } = ShakeType.None;

        /// <summary>
        /// Shake weight/intensity
        /// </summary>
        [MemoryPackOrder(56)]
        [JsonPropertyName("ShakeWeight")]
        public int ShakeWeight { get; set; }

        /// <summary>
        /// Aim prefab (optional field, appears only for certain weapon types)
        /// </summary>
        [MemoryPackOrder(57)]
        [JsonPropertyName("aim_prefab")]
        public string? AimPrefab { get; set; } = String.Empty;
    }
}