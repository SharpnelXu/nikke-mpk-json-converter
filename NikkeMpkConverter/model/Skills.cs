using MemoryPack;
using System.Text.Json.Serialization;

namespace NikkeMpkConverter.model
{
    public enum CharacterSkillType
    {
        None = 0,
        SetBuff = 8,
        InstantAll = 6,
        InstantArea = 15,
        InstantCircle = 4,
        InstantCircleSeparate = 5,
        InstantNumber = 2,
        InstantSequentialAttack = 7,
        InstallBarrier = 1,
        InstallDecoy = 9,
        ChangeWeapon = 10,
        LaunchWeapon = 11,
        LaserBeam = 12,
        ExplosiveCircuit = 13,
        Stigma = 14,
        HitMonsterGetBuff = 20,
        InstantAllParts = 16,
        TargetHitCountGetBuff = 17,
        Unknown = -1
    }

    public enum DurationType
    {
        None = 0,
        TimeSec = 1,
        Shots = 2,
        Battles = 3,
        Hits = 4,
        TimeSecBattles = 5,
        [JsonPropertyName("TimeSec_Ver2")]
        TimeSecVer2 = 6,
        [JsonPropertyName("Hits_Ver2")]
        HitsVer2 = 7,
        ReloadAllAmmoCount = 8,
        Unknown = -1
    }

    public enum ValueType
    {
        None = 0,
        Integer = 1,
        Percent = 2,
        Unknown = -1
    }

    public enum BuffType
    {
        Etc = 0,
        Buff = 1,
        BuffEtc = 2,
        DeBuff = 3,
        DeBuffEtc = 4,
        Unknown = -1
    }

    public enum BuffRemoveType
    {
        None = 0,
        Etc = 1,
        Clear = 2,
        Resist = 3,
        Unknown = -1
    }

    public enum FunctionType
    {
        Unknown = -1,
        AddDamage = 1,
        AddIncElementDmgType = 2,
        AllAmmo = 3,
        AllStepBurstNextStep = 4,
        AtkBuffChange = 5,
        AtkChangHpRate = 6,
        AtkChangeMaxHpRate = 7,
        AtkReplaceMaxHpRate = 8,
        Attention = 9,
        BarrierDamage = 10,
        BonusRangeDamageChange = 11,
        BreakDamage = 12,
        BuffRemove = 13,
        BurstGaugeCharge = 14,
        CallingMonster = 15,
        ChangeChangeBurstStep = 16,
        ChangeCoolTimeAll = 17,
        ChangeCoolTimeSkill1 = 18,
        ChangeCoolTimeSkill2 = 19,
        ChangeCoolTimeUlti = 20,
        ChangeCurrentHpValue = 21,
        ChangeMaxSkillCoolTime1 = 22,
        ChangeMaxSkillCoolTime2 = 23,
        ChangeMaxSkillCoolTimeUlti = 24,
        ChangeNormalDefIgnoreDamage = 25,
        ChargeDamageChangeMaxStatAmmo = 26,
        ChargeTimeChangetoDamage = 27,
        ChangeUseBurstSkill = 28,
        CopyAtk = 29,
        CopyHp = 30,
        CoreShotDamageChange = 31,
        CoverResurrection = 32,
        CurrentHpRatioDamage = 33,
        CycleUse = 34,
        Damage = 35,
        DamageBio = 36,
        DamageEnergy = 37,
        DamageFunctionTargetGroupId = 38,
        DamageFunctionUnable = 39,
        DamageFunctionValueChange = 40,
        DamageMetal = 41,
        DamageRatioEnergy = 42,
        DamageRatioMetal = 43,
        DamageReduction = 44,
        DamageShare = 45,
        DamageShareInstant = 46,
        DamageShareInstantUnable = 47,
        DebuffImmune = 48,
        DebuffRemove = 49,
        DefChangHpRate = 50,
        DefIgnoreDamage = 51,
        DefIgnoreDamageRatio = 52,
        DrainHpBuff = 53,
        DurationDamageRatio = 54,
        DurationValueChange = 55,
        ExplosiveCircuitAccrueDamageRatio = 56,
        FinalStatHpHeal = 57,
        FirstBurstGaugeSpeedUp = 58,
        FixStatReloadTime = 59,
        ForcedStop = 60,
        FullChargeHitDamageRepeat = 61,
        FullCountDamageRatio = 62,
        FunctionOverlapChange = 63,
        GainAmmo = 64,
        GainUltiGauge = 65,
        GivingHealVariation = 66,
        GravityBomb = 67,
        HealBarrier = 68,
        HealCharacter = 69,
        HealCover = 70,
        HealDecoy = 71,
        HealShare = 72,
        HealVariation = 73,
        Hide = 74,
        HpProportionDamage = 75,
        ImmuneAttention = 76,
        ImmuneBio = 77,
        ImmuneChangeCoolTimeUlti = 78,
        ImmuneDamage = 79,
        ImmuneDamage_MainHp = 80,
        ImmuneEnergy = 81,
        ImmuneForcedStop = 82,
        ImmuneGravityBomb = 83,
        ImmuneInstantDeath = 84,
        ImmuneInstallBarrier = 85,
        ImmuneMetal = 86,
        ImmuneOtherElement = 87,
        ImmuneStun = 88,
        ImmuneTaunt = 89,
        Immortal = 90,
        IncBarrierHp = 91,
        IncBurstDuration = 92,
        IncElementDmg = 93,
        Infection = 94,
        InstantAllBurstDamage = 95,
        InstantDeath = 96,
        LinkAtk = 97,
        LinkDef = 98,
        None = 0,
        NormalDamageRatioChange = 99,
        NormalStatCritical = 100,
        OutBonusRangeDamageChange = 101,
        OverHealSave = 102,
        PartsDamage = 103,
        PartsHpChangeUIOff = 104,
        PartsHpChangeUIOn = 105,
        PartsImmuneDamage = 106,
        PenetrationDamage = 107,
        PlusDebuffCount = 108,
        PlusInstantSkillTargetNum = 109,
        ProjectileDamage = 110,
        ProjectileExplosionDamage = 111,
        RemoveFunctionGroup = 112,
        RepeatUseBurstStep = 113,
        Resurrection = 114,
        ShareDamageIncrease = 115,
        Silence = 116,
        SingleBurstDamage = 117,
        StatAccuracyCircle = 118,
        StatAmmo = 119,
        StatAmmoLoad = 120,
        StatAtk = 121,
        StatBioResist = 122,
        StatBonusRangeMax = 123,
        StatBurstSkillCoolTime = 124,
        StatChargeDamage = 125,
        StatChargeTime = 126,
        StatChargeTimeImmune = 127,
        StatCritical = 128,
        StatCriticalDamage = 129,
        StatDef = 130,
        StatEndRateOfFire = 131,
        StatEnergyResist = 132,
        StatExplosion = 133,
        StatHp = 134,
        StatHpHeal = 135,
        StatInstantSkillRange = 136,
        StatMaintainFireStance = 137,
        StatPenetration = 138,
        StatRateOfFire = 139,
        StatRateOfFirePerShot = 140,
        StatReloadBulletRatio = 141,
        StatReloadTime = 142,
        StatShotCount = 143,
        StatSpotRadius = 144,
        StickyProjectileCollisionDamage = 145,
        StickyProjectileExplosion = 146,
        StickyProjectileInstantExplosion = 147,
        Stun = 148,
        Taunt = 149,
        TargetGroupid = 150,
        TargetPartsId = 151,
        TimingTriggerValueChange = 152,
        Transformation = 153,
        Uncoverable = 154,
        UseCharacterSkillId = 155,
        UseSkill2 = 156,
        WindReduction = 157,
        FocusAttack = 158,
        NoOverlapStatAmmo = 159,
        DmgReductionExcludingBreakCol = 160,
        DurationBuffCheckImmune = 161,
        ImmediatelyBuffCheckImmune = 162,
        ChangeHurtFxExcludingBreakCol = 163,
        PlusBuffCount = 164,
        DurationDamage = 165,
        UseSkill1 = 166,
        DefIgnoreSkillDamageInstant = 167,
        ForcedReload = 168,
        StatBonusRangeMin = 169,
        DamageShareLowestPriority = 170
    }

    public enum StandardType
    {
        Unknown = -1,
        None = 0,
        User = 1,
        FunctionTarget = 2,
        TriggerTarget = 3
    }

    public enum FunctionTargetType
    {
        Unknown = -1,
        None = 0,
        Self = 1,
        Target = 2,
        TargetCover = 3,
        AllCharacter = 4,
        AllMonster = 5,
        UserCover = 6
    }

    public enum TimingTriggerType
    {
        Unknown = -1,
        None = 0,
        OnAmmoRatioUnder = 1,
        OnBurstSkillStep = 2,
        OnBurstSkillUseNum = 3,
        OnCheckTime = 4,
        OnCoreHitNum = 5,
        OnCoreHitNumOnce = 6,
        OnCoreHitRatio = 7,
        OnCoverHurtRatio = 8,
        OnCriticalHitNum = 9,
        OnDead = 10,
        OnEndFullBurst = 11,
        OnEndReload = 12,
        OnEnterBurstStep = 13,
        OnFullCharge = 14,
        OnFullChargeHit = 15,
        OnFullChargeHitNum = 16,
        OnFullChargeNum = 17,
        OnFullChargeShot = 18,
        OnFullChargeShotNum = 19,
        OnFullCount = 20,
        OnFunctionBuffCheck = 21,
        OnFunctionOff = 22,
        OnFunctionOn = 23,
        OnHealCover = 24,
        OnHealedBy = 25,
        OnHitNum = 26,
        OnHitNumExceptCore = 27,
        OnHitNumberOver = 28,
        OnHitRatio = 29,
        OnHpRatioUnder = 30,
        OnHpRatioUp = 31,
        OnHurtCount = 32,
        OnHurtRatio = 33,
        OnInstallBarrier = 34,
        OnInstantDeath = 35,
        OnKeepFullcharge = 36,
        OnKillRatio = 37,
        OnLastAmmoUse = 38,
        OnLastShotHit = 39,
        OnNikkeDead = 40,
        OnPartsBrokenNum = 41,
        OnPartsHitNum = 42,
        OnPartsHitRatio = 43,
        OnPartsHurtCount = 44,
        OnPelletHitNum = 45,
        OnPelletHitPerShot = 46,
        OnResurrection = 47,
        OnShotNotFullCharge = 48,
        OnShotRatio = 49,
        OnSkillUse = 50,
        OnSpawnMonster = 51,
        OnSpawnTarget = 52,
        OnSquadHurtRatio = 53,
        OnStart = 54,
        OnSummonMonster = 55,
        OnTeamHpRatioUnder = 56,
        OnTeamHpRatioUp = 57,
        OnUseAmmo = 58,
        OnUseBurstSkill = 59,
        OnUserPartsDestroy = 60,
        OnSpawnEnemy = 61,
        OnEnemyDead = 62,
        OnUseTeamAmmo = 63,
        OnPelletCriticalHitNum = 64,
        OnFunctionDamageCriticalHit = 65,
        OnFullChargeBonusRangeHitNum = 66
    }

    public enum StatusTriggerType
    {
        Unknown = -1,
        None = 0,
        IsAlive = 1,
        IsAmmoCount = 2,
        IsBurstMember = 3,
        IsBurstStepState = 4,
        IsCharacter = 5,
        IsCheckFunctionOverlapUp = 6,
        IsCheckMonster = 7,
        IsCheckMonsterType = 8,
        IsCheckPartsId = 9,
        IsCheckPosition = 10,
        IsCheckTarget = 11,
        IsCheckTeamBurstNextStep = 12,
        IsClassType = 13,
        IsCover = 14,
        IsExplosiveCircuitOff = 15,
        IsFullCharge = 16,
        IsFullCount = 17,
        IsFunctionBuffCheck = 18,
        IsFunctionOff = 19,
        IsFunctionOn = 20,
        IsFunctionTypeOffCheck = 21,
        IsHaveBarrier = 22,
        IsHaveDecoy = 23,
        IsHpRatioUnder = 24,
        IsHpRatioUp = 25,
        IsNotBurstMember = 26,
        IsNotCheckTeamBurstNextStep = 27,
        IsNotHaveBarrier = 28,
        isPhase = 29,
        IsSameSqaudCount = 30,
        IsSameSqaudUp = 31,
        IsSearchElementId = 32,
        IsStun = 33,
        IsWeaponType = 34,
        IsCheckEnemyNikke = 35,
        IsCheckMonsterExcludeNoneType = 36,
        IsBurstStepCheck = 37,
        IsFunctionCount = 38,
        IsNotHaveCover = 39,
        IsSameSqaud = 40
    }

    public enum FunctionStatus
    {
        On = 1,
        Off = 0,
        Unknown = -1
    }

    /// <summary>
    /// Represents skill value data containing type and value information
    /// </summary>
    [MemoryPackable]
    public partial class SkillValueData
    {
        /// <summary>
        /// Raw skill value type string
        /// </summary>
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("skill_value_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ValueType SkillValueType { get; set; } = ValueType.Unknown;

        /// <summary>
        /// Skill value numeric value
        /// </summary>
        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("skill_value")]
        public long SkillValue { get; set; }
    }

    /// <summary>
    /// Represents character skill data
    /// </summary>
    [MemoryPackable]
    public partial class SkillData
    {
        /// <summary>
        /// Unique skill identifier
        /// </summary>
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Skill cooldown time
        /// </summary>
        [MemoryPackOrder(5)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("skill_cooltime")]
        public int SkillCooltime { get; set; }

        /// <summary>
        /// Raw attack type string
        /// </summary>
        [MemoryPackOrder(1)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("attack_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttackType AttackType { get; set; } = AttackType.None;

        /// <summary>
        /// Counter type information
        /// </summary>
        [MemoryPackOrder(2)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("counter_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CounterType CounterType { get; set; } = CounterType.None;

        /// <summary>
        /// Raw preferred target string
        /// </summary>
        [MemoryPackOrder(3)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("prefer_target")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PreferTarget PreferTarget { get; set; } = PreferTarget.None;

        /// <summary>
        /// Raw preferred target condition string
        /// </summary>
        [MemoryPackOrder(4)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("prefer_target_condition")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PreferTargetCondition PreferTargetCondition { get; set; } = PreferTargetCondition.None;

        /// <summary>
        /// Raw skill type string
        /// </summary>
        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("skill_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CharacterSkillType SkillType { get; set; } = CharacterSkillType.None;

        /// <summary>
        /// List of skill value data
        /// </summary>
        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("skill_value_data")]
        public SkillValueData[] SkillValueData { get; set; } = [];

        /// <summary>
        /// Raw duration type string
        /// </summary>
        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("duration_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DurationType DurationType { get; set; } = DurationType.None;

        /// <summary>
        /// Duration value
        /// </summary>
        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("duration_value")]
        public int DurationValue { get; set; }

        /// <summary>
        /// Function IDs to execute before skill use
        /// </summary>
        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("before_use_function_id_list")]
        public int[] BeforeUseFunctionIdList { get; set; } = [];

        /// <summary>
        /// Function IDs to execute before hurt
        /// </summary>
        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("before_hurt_function_id_list")]
        public int[] BeforeHurtFunctionIdList { get; set; } = [];

        /// <summary>
        /// Function IDs to execute after skill use
        /// </summary>
        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("after_use_function_id_list")]
        public int[] AfterUseFunctionIdList { get; set; } = [];

        /// <summary>
        /// Function IDs to execute after hurt
        /// </summary>
        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("after_hurt_function_id_list")]
        public int[] AfterHurtFunctionIdList { get; set; } = [];

        /// <summary>
        /// Resource name for the skill
        /// </summary>
        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("resource_name")]
        public string ResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Icon identifier
        /// </summary>
        [MemoryPackOrder(16)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Shake effect identifier
        /// </summary>
        [MemoryPackOrder(15)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("shake_id")]
        public int ShakeId { get; set; }
    }

    /// <summary>
    /// Represents a skill function reference
    /// </summary>
    [MemoryPackable]
    public partial class SkillFunction
    {
        /// <summary>
        /// Function identifier
        /// </summary>
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("function")]
        public int Function { get; set; }
    }

    /// <summary>
    /// Represents state effect data
    /// </summary>
    [MemoryPackable]
    public partial class StateEffectData
    {
        /// <summary>
        /// Unique state effect identifier
        /// </summary>
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Function IDs to use
        /// </summary>
        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("use_function_id_list")]
        public int[] UseFunctionIdList { get; set; } = [];

        /// <summary>
        /// Function IDs for hurt effects
        /// </summary>
        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("hurt_function_id_list")]
        public int[] HurtFunctionIdList { get; set; } = [];

        /// <summary>
        /// List of skill functions
        /// </summary>
        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("functions")]
        public SkillFunction[] Functions { get; set; } = [];

        /// <summary>
        /// Icon identifier
        /// </summary>
        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }

    /// <summary>
    /// Represents function data with all related properties
    /// </summary>
    [MemoryPackable]
    public partial class FunctionData
    {
        /// <summary>
        /// Unique function identifier
        /// </summary>
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Function group identifier
        /// </summary>
        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// Function level
        /// </summary>
        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// Name localization key
        /// </summary>
        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("name_localkey")]
        public string? NameLocalkey { get; set; }

        /// <summary>
        /// Raw buff type string
        /// </summary>
        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("buff")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BuffType BuffType { get; set; } = BuffType.Unknown;

        /// <summary>
        /// Raw buff remove type string
        /// </summary>
        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("buff_remove")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BuffRemoveType BuffRemoveType { get; set; } = BuffRemoveType.None;

        /// <summary>
        /// Raw function type string
        /// </summary>
        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("function_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FunctionType FunctionType { get; set; } = FunctionType.None;

        /// <summary>
        /// Raw function value type string
        /// </summary>
        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("function_value_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ValueType FunctionValueType { get; set; } = ValueType.None;

        /// <summary>
        /// Raw function standard string
        /// </summary>
        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("function_standard")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StandardType FunctionStandard { get; set; } = StandardType.None;

        /// <summary>
        /// Function value
        /// </summary>
        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("function_value")]
        public int FunctionValue { get; set; }

        /// <summary>
        /// Full count value
        /// </summary>
        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("full_count")]
        public int FullCount { get; set; }

        /// <summary>
        /// Whether function is cancellable
        /// </summary>
        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("is_cancel")]
        public bool IsCancel { get; set; }

        /// <summary>
        /// Raw delay type string
        /// </summary>
        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("delay_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DurationType DelayType { get; set; } = DurationType.None;

        /// <summary>
        /// Delay value
        /// </summary>
        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("delay_value")]
        public int DelayValue { get; set; }

        /// <summary>
        /// Raw duration type string
        /// </summary>
        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("duration_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DurationType DurationType { get; set; } = DurationType.None;

        /// <summary>
        /// Duration value
        /// </summary>
        [MemoryPackOrder(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("duration_value")]
        public int DurationValue { get; set; }

        /// <summary>
        /// Limit value
        /// </summary>
        [MemoryPackOrder(16)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("limit_value")]
        public int LimitValue { get; set; }

        /// <summary>
        /// Raw function target string
        /// </summary>
        [MemoryPackOrder(17)]
        [JsonPropertyOrder(17)]
        [JsonPropertyName("function_target")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FunctionTargetType FunctionTarget { get; set; } = FunctionTargetType.None;

        /// <summary>
        /// Raw timing trigger type string
        /// </summary>
        [MemoryPackOrder(18)]
        [JsonPropertyOrder(18)]
        [JsonPropertyName("timing_trigger_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimingTriggerType TimingTriggerType { get; set; } = TimingTriggerType.None;

        /// <summary>
        /// Raw timing trigger standard string
        /// </summary>
        [MemoryPackOrder(19)]
        [JsonPropertyOrder(19)]
        [JsonPropertyName("timing_trigger_standard")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StandardType TimingTriggerStandard { get; set; } = StandardType.None;

        /// <summary>
        /// Timing trigger value
        /// </summary>
        [MemoryPackOrder(20)]
        [JsonPropertyOrder(20)]
        [JsonPropertyName("timing_trigger_value")]
        public int TimingTriggerValue { get; set; }

        /// <summary>
        /// Raw status trigger type string
        /// </summary>
        [MemoryPackOrder(21)]
        [JsonPropertyOrder(21)]
        [JsonPropertyName("status_trigger_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusTriggerType StatusTriggerType { get; set; } = StatusTriggerType.None;

        /// <summary>
        /// Raw status trigger standard string
        /// </summary>
        [MemoryPackOrder(22)]
        [JsonPropertyOrder(22)]
        [JsonPropertyName("status_trigger_standard")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StandardType StatusTriggerStandard { get; set; } = StandardType.None;

        /// <summary>
        /// Status trigger value
        /// </summary>
        [MemoryPackOrder(23)]
        [JsonPropertyOrder(23)]
        [JsonPropertyName("status_trigger_value")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public int StatusTriggerValue { get; set; }

        /// <summary>
        /// Raw status trigger 2 type string
        /// </summary>
        [MemoryPackOrder(24)]
        [JsonPropertyOrder(24)]
        [JsonPropertyName("status_trigger2_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusTriggerType StatusTrigger2Type { get; set; } = StatusTriggerType.None;

        /// <summary>
        /// Raw status trigger 2 standard string
        /// </summary>
        [MemoryPackOrder(25)]
        [JsonPropertyOrder(25)]
        [JsonPropertyName("status_trigger2_standard")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StandardType StatusTrigger2Standard { get; set; } = StandardType.None;

        /// <summary>
        /// Status trigger 2 value
        /// </summary>
        [MemoryPackOrder(26)]
        [JsonPropertyOrder(26)]
        [JsonPropertyName("status_trigger2_value")]
        public int StatusTrigger2Value { get; set; }

        /// <summary>
        /// Raw keeping type string
        /// </summary>
        [MemoryPackOrder(27)]
        [JsonPropertyOrder(27)]
        [JsonPropertyName("keeping_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FunctionStatus KeepingType { get; set; } = FunctionStatus.Off;

        /// <summary>
        /// Buff icon identifier
        /// </summary>
        [MemoryPackOrder(28)]
        [JsonPropertyOrder(28)]
        [JsonPropertyName("buff_icon")]
        public string BuffIcon { get; set; } = string.Empty;

        /// <summary>
        /// Shot FX list type
        /// </summary>
        [MemoryPackOrder(29)]
        [JsonPropertyOrder(29)]
        [JsonPropertyName("shot_fx_list_type")]
        public string? ShotFxListType { get; set; }

        /// <summary>
        /// FX prefab 01
        /// </summary>
        [MemoryPackOrder(30)]
        [JsonPropertyOrder(30)]
        [JsonPropertyName("fx_prefab_01")]
        public string? FxPrefab01 { get; set; }

        /// <summary>
        /// FX target 01
        /// </summary>
        [MemoryPackOrder(31)]
        [JsonPropertyOrder(31)]
        [JsonPropertyName("fx_target_01")]
        public string? FxTarget01 { get; set; }

        /// <summary>
        /// FX socket point 01
        /// </summary>
        [MemoryPackOrder(32)]
        [JsonPropertyOrder(32)]
        [JsonPropertyName("fx_socket_point_01")]
        public string? FxSocketPoint01 { get; set; }

        /// <summary>
        /// FX prefab 02
        /// </summary>
        [MemoryPackOrder(33)]
        [JsonPropertyOrder(33)]
        [JsonPropertyName("fx_prefab_02")]
        public string? FxPrefab02 { get; set; }

        /// <summary>
        /// FX target 02
        /// </summary>
        [MemoryPackOrder(34)]
        [JsonPropertyOrder(34)]
        [JsonPropertyName("fx_target_02")]
        public string? FxTarget02 { get; set; }

        /// <summary>
        /// FX socket point 02
        /// </summary>
        [MemoryPackOrder(35)]
        [JsonPropertyOrder(35)]
        [JsonPropertyName("fx_socket_point_02")]
        public string? FxSocketPoint02 { get; set; }

        /// <summary>
        /// FX prefab 03
        /// </summary>
        [MemoryPackOrder(36)]
        [JsonPropertyOrder(36)]
        [JsonPropertyName("fx_prefab_03")]
        public string? FxPrefab03 { get; set; }

        /// <summary>
        /// FX target 03
        /// </summary>
        [MemoryPackOrder(37)]
        [JsonPropertyOrder(37)]
        [JsonPropertyName("fx_target_03")]
        public string? FxTarget03 { get; set; }

        /// <summary>
        /// FX socket point 03
        /// </summary>
        [MemoryPackOrder(38)]
        [JsonPropertyOrder(38)]
        [JsonPropertyName("fx_socket_point_03")]
        public string? FxSocketPoint03 { get; set; }

        /// <summary>
        /// FX prefab full
        /// </summary>
        [MemoryPackOrder(39)]
        [JsonPropertyOrder(39)]
        [JsonPropertyName("fx_prefab_full")]
        public string? FxPrefabFull { get; set; }

        /// <summary>
        /// FX target full
        /// </summary>
        [MemoryPackOrder(40)]
        [JsonPropertyOrder(40)]
        [JsonPropertyName("fx_target_full")]
        public string? FxTargetFull { get; set; }

        /// <summary>
        /// FX socket point full
        /// </summary>
        [MemoryPackOrder(41)]
        [JsonPropertyOrder(41)]
        [JsonPropertyName("fx_socket_point_full")]
        public string? FxSocketPointFull { get; set; }

        /// <summary>
        /// FX prefab 01 arena
        /// </summary>
        [MemoryPackOrder(42)]
        [JsonPropertyOrder(42)]
        [JsonPropertyName("fx_prefab_01_arena")]
        public string? FxPrefab01Arena { get; set; }

        /// <summary>
        /// FX target 01 arena
        /// </summary>
        [MemoryPackOrder(43)]
        [JsonPropertyOrder(43)]
        [JsonPropertyName("fx_target_01_arena")]
        public string? FxTarget01Arena { get; set; }

        /// <summary>
        /// FX socket point 01 arena
        /// </summary>
        [MemoryPackOrder(44)]
        [JsonPropertyOrder(44)]
        [JsonPropertyName("fx_socket_point_01_arena")]
        public string? FxSocketPoint01Arena { get; set; }

        /// <summary>
        /// FX prefab 02 arena
        /// </summary>
        [MemoryPackOrder(45)]
        [JsonPropertyOrder(45)]
        [JsonPropertyName("fx_prefab_02_arena")]
        public string? FxPrefab02Arena { get; set; }

        /// <summary>
        /// FX target 02 arena
        /// </summary>
        [MemoryPackOrder(46)]
        [JsonPropertyOrder(46)]
        [JsonPropertyName("fx_target_02_arena")]
        public string? FxTarget02Arena { get; set; }

        /// <summary>
        /// FX socket point 02 arena
        /// </summary>
        [MemoryPackOrder(47)]
        [JsonPropertyOrder(47)]
        [JsonPropertyName("fx_socket_point_02_arena")]
        public string? FxSocketPoint02Arena { get; set; }

        /// <summary>
        /// FX prefab 03 arena
        /// </summary>
        [MemoryPackOrder(48)]
        [JsonPropertyOrder(48)]
        [JsonPropertyName("fx_prefab_03_arena")]
        public string? FxPrefab03Arena { get; set; }

        /// <summary>
        /// FX target 03 arena
        /// </summary>
        [MemoryPackOrder(49)]
        [JsonPropertyOrder(49)]
        [JsonPropertyName("fx_target_03_arena")]
        public string? FxTarget03Arena { get; set; }

        /// <summary>
        /// FX socket point 03 arena
        /// </summary>
        [MemoryPackOrder(50)]
        [JsonPropertyOrder(50)]
        [JsonPropertyName("fx_socket_point_03_arena")]
        public string? FxSocketPoint03Arena { get; set; }

        /// <summary>
        /// Connected function identifiers
        /// </summary>
        [MemoryPackOrder(51)]
        [JsonPropertyOrder(51)]
        [JsonPropertyName("connected_function")]
        public int[] ConnectedFunction { get; set; } = [];

        /// <summary>
        /// Description localization key
        /// </summary>
        [MemoryPackOrder(52)]
        [JsonPropertyOrder(52)]
        [JsonPropertyName("description_localkey")]
        public string? DescriptionLocalkey { get; set; }

        /// <summary>
        /// Element reaction icon
        /// </summary>
        [MemoryPackOrder(53)]
        [JsonPropertyOrder(53)]
        [JsonPropertyName("element_reaction_icon")]
        public string? ElementReactionIcon { get; set; }

        /// <summary>
        /// Function battle power
        /// </summary>
        [MemoryPackOrder(54)]
        [JsonPropertyOrder(54)]
        [JsonPropertyName("function_battlepower")]
        public int? FunctionBattlepower { get; set; }
    }

    /// <summary>
    /// Represents skill description value
    /// </summary>
    [MemoryPackable]
    public partial class SkillDescriptionValue
    {
        /// <summary>
        /// Description value string
        /// </summary>
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("description_value")]
        public string? Value { get; set; }
    }

    /// <summary>
    /// Represents skill info data
    /// </summary>
    [MemoryPackable]
    public partial class SkillInfoData
    {
        /// <summary>
        /// Unique skill info identifier
        /// </summary>
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Skill group identifier
        /// </summary>
        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// Skill level
        /// </summary>
        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("skill_level")]
        public int SkillLevel { get; set; }

        /// <summary>
        /// Next level identifier
        /// </summary>
        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("next_level_id")]
        public int NextLevelId { get; set; }

        /// <summary>
        /// Level up cost identifier
        /// </summary>
        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("level_up_cost_id")]
        public int LevelUpCostId { get; set; }

        /// <summary>
        /// Icon identifier
        /// </summary>
        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Name localization key
        /// </summary>
        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("name_localkey")]
        public string NameLocalkey { get; set; } = string.Empty;

        /// <summary>
        /// Description localization key
        /// </summary>
        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionLocalkey { get; set; } = string.Empty;

        /// <summary>
        /// Info description localization key
        /// </summary>
        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("info_description_localkey")]
        public string InfoDescriptionLocalkey { get; set; } = string.Empty;

        /// <summary>
        /// Description values list
        /// </summary>
        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("description_value_list")]
        public SkillDescriptionValue[] DescriptionValues { get; set; } = [];
    }
}