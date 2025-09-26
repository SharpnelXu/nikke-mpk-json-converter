using MemoryPack;
using System.Text.Json.Serialization;

namespace NikkeMpkConverter.model
{
    public enum PartsType
    {
        Unknown = -1,
        Body = 6, 
        Arm_Left,
        Arm_Right,
        Leg_Front_Left,
        Leg_Front_Right,
        Head,
        Weapon_01,
        Weapon_02,
        Weapon_03,
        Weapon_04,
        Weapon_05,
        Weapon_06,
        Weapon_07,
        Weapon_08,
        Weapon_09,
        Weapon_10,
        Body_Lower,
        Body_Upper,
        Chest,
        Belly,
        Leg_Back_Left,
        Leg_Back_Right
    }

    public enum MonsterDestroyAnimTrigger
    {
        Unknown = -1,
        None = 0,
        Destruction_01,
        Destruction_02,
        Destruction_03,
        Destruction_04,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WeaponObject
    {
        Unknown = -1,
        None = 0,
        Weapon_object_01,
        Weapon_object_02,
        Weapon_object_03,
        Weapon_object_04,
        Weapon_object_05,
        Weapon_object_06,
        Weapon_object_07,
        Weapon_object_08,
        Weapon_object_09,
        Weapon_object_10,
        Weapon_object_11,
        Weapon_object_12,
        Weapon_object_13,
        Weapon_object_14,

        Weapon_object_15,
        Weapon_object_16,
        Weapon_object_17,
        Weapon_object_18,
        Weapon_object_19,
        Weapon_object_20
    }

    /// <summary>
    /// Monster skill information data containing function IDs
    /// </summary>
    [MemoryPackable]
    public partial class MonsterSkillInfoData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("skill_id")]
        public int SkillId { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("use_function_id_skill")]
        public int[] UseFunctionIds { get; set; } = [];

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("hurt_function_id_skill")]
        public int[] HurtFunctionIds { get; set; } = [];
    }

    /// <summary>
    /// Monster data from MonsterTable
    /// </summary>
    [MemoryPackable]
    public partial class MonsterData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("element_id")]
        public int[] ElementIds { get; set; } = [];

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("monster_model_id")]
        public int MonsterModelId { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("name_localkey")]
        public string NameKey { get; set; } = string.Empty;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("appearance_localkey")]
        public string AppearanceKey { get; set; } = string.Empty;

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("description_localkey")]
        public string DescriptionKey { get; set; } = string.Empty;

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("is_irregular")]
        public bool IsIrregular { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("hp_ratio")]
        public int HpRatio { get; set; }

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("attack_ratio")]
        public int AttackRatio { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("defence_ratio")]
        public int DefenceRatio { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("energy_resist_ratio")]
        public int EnergyResistRatio { get; set; }

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("metal_resist_ratio")]
        public int MetalResistRatio { get; set; }

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("bio_resist_ratio")]
        public int BioResistRatio { get; set; }

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("detector_center")]
        public int DetectorCenter { get; set; }

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("detector_radius")]
        public int DetectorRadius { get; set; }

        [MemoryPackOrder(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("nonetarget")]
        public string Nonetarget { get; set; } = "Normal";

        [MemoryPackOrder(16)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("functionnonetarget")]
        public string FunctionNonetarget { get; set; } = "Normal";

        [MemoryPackOrder(17)]
        [JsonPropertyOrder(17)]
        [JsonPropertyName("spot_ai")]
        public string SpotAi { get; set; } = string.Empty;

        [MemoryPackOrder(18)]
        [JsonPropertyOrder(18)]
        [JsonPropertyName("spot_ai_defense")]
        public string SpotAiDefense { get; set; } = string.Empty;

        [MemoryPackOrder(19)]
        [JsonPropertyOrder(19)]
        [JsonPropertyName("spot_ai_basedefense")]
        public string SpotAiBaseDefense { get; set; } = string.Empty;

        [MemoryPackOrder(20)]
        [JsonPropertyOrder(20)]
        [JsonPropertyName("spot_move_speed")]
        public int SpotMoveSpeed { get; set; }

        [MemoryPackOrder(21)]
        [JsonPropertyOrder(21)]
        [JsonPropertyName("spot_acceleration_time")]
        public int SpotAccelerationTime { get; set; }

        [MemoryPackOrder(22)]
        [JsonPropertyOrder(22)]
        [JsonPropertyName("fixed_spawn_type")]
        public string FixedSpawnType { get; set; } = string.Empty;

        [MemoryPackOrder(23)]
        [JsonPropertyOrder(23)]
        [JsonPropertyName("spot_rand_ratio_normal")]
        public int SpotRandRatioNormal { get; set; }

        [MemoryPackOrder(24)]
        [JsonPropertyOrder(24)]
        [JsonPropertyName("spot_rand_ratio_jump")]
        public int SpotRandRatioJump { get; set; }

        [MemoryPackOrder(25)]
        [JsonPropertyOrder(25)]
        [JsonPropertyName("spot_rand_ratio_drop")]
        public int SpotRandRatioDrop { get; set; }

        [MemoryPackOrder(26)]
        [JsonPropertyOrder(26)]
        [JsonPropertyName("spot_rand_ratio_dash")]
        public int SpotRandRatioDash { get; set; }

        [MemoryPackOrder(27)]
        [JsonPropertyOrder(27)]
        [JsonPropertyName("spot_rand_ratio_teleport")]
        public int SpotRandRatioTeleport { get; set; }

        [MemoryPackOrder(28)]
        [JsonPropertyOrder(28)]
        [JsonPropertyName("skill_data")]
        public MonsterSkillInfoData[] SkillData { get; set; } = [];

        [MemoryPackOrder(29)]
        [JsonPropertyOrder(29)]
        [JsonPropertyName("statenhance_id")]
        public int StatEnhanceId { get; set; }

        [MemoryPackOrder(30)]
        [JsonPropertyOrder(30)]
        [JsonPropertyName("ui_grade")]
        public string? UiGrade { get; set; }

        [MemoryPackOrder(31)]
        [JsonPropertyOrder(31)]
        [JsonPropertyName("passive_skill_id")]
        public int? PassiveSkillId { get; set; }
    }

    /// <summary>
    /// Monster stat enhancement data from MonsterStatEnhanceTable
    /// </summary>
    [MemoryPackable]
    public partial class MonsterStatEnhanceData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("lv")]
        public int Lv { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("level_hp")]
        public int LevelHp { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("level_attack")]
        public int LevelAttack { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("level_defence")]
        public int LevelDefence { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("level_statdamageratio")]
        public int LevelStatDamageRatio { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("level_energy_resist")]
        public int LevelEnergyResist { get; set; }

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("level_metal_resist")]
        public int LevelMetalResist { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("level_bio_resist")]
        public int LevelBioResist { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("level_projectile_hp")]
        public int LevelProjectileHp { get; set; }

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("level_broken_hp")]
        public int LevelBrokenHp { get; set; }
    }

    /// <summary>
    /// Monster part data from MonsterPartsTable
    /// </summary>
    [MemoryPackable]
    public partial class MonsterPartData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("monster_model_id")]
        public int MonsterModelId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("parts_name_localkey")]
        public string? PartsNameLocalKey { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("damage_hp_ratio")]
        public int DamageHpRatio { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("hp_ratio")]
        public int HpRatio { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("defence_ratio")]
        public int DefenceRatio { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("destroy_after_anim")]
        public bool DestroyAfterAnim { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("destroy_after_movable")]
        public bool DestroyAfterMovable { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("passive_skill_id")]
        public int PassiveSkillId { get; set; }

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("visible_hp")]
        public bool VisibleHp { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("linked_parts_id")]
        public int LinkedPartsId { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("weapon_object")]
        public string[] WeaponObject { get; set; } = [];

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("weapon_object_enum")]
        public WeaponObject[] WeaponObjectEnum { get; set; } = [];

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("parts_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PartsType PartsType { get; set; } = PartsType.Unknown;

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("parts_object")]
        public string[] PartsObject { get; set; } = [];

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("energy_resist_ratio")]
        public int EnergyResistRatio { get; set; }

        [MemoryPackOrder(15)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("metal_resist_ratio")]
        public int MetalResistRatio { get; set; }

        [MemoryPackOrder(16)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("bio_resist_ratio")]
        public int BioResistRatio { get; set; }

        [MemoryPackOrder(17)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("attack_ratio")]
        public int AttackRatio { get; set; }


        [MemoryPackOrder(18)]
        [JsonPropertyOrder(18)]
        [JsonPropertyName("parts_skin")]
        public string? PartsSkin { get; set; } = string.Empty;

        [MemoryPackOrder(19)]
        [JsonPropertyOrder(19)]
        [JsonPropertyName("monster_destroy_anim_trigger")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MonsterDestroyAnimTrigger DestroyAnimTrigger { get; set; } = MonsterDestroyAnimTrigger.Unknown;

        [MemoryPackOrder(20)]
        [JsonPropertyOrder(20)]
        [JsonPropertyName("is_main_part")]
        public bool IsMainPart { get; set; }

        [MemoryPackOrder(21)]
        [JsonPropertyOrder(21)]
        [JsonPropertyName("is_parts_damage_able")]
        public bool IsPartsDamageAble { get; set; }
    }

    /// <summary>
    /// Monster stage level change data from MonsterStageLvChangeTable
    /// </summary>
    [MemoryPackable]
    public partial class MonsterStageLevelChangeData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("group")]
        public int Group { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("step")]
        public int Step { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("condition_type")]
        public string ConditionType { get; set; } = string.Empty;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("condition_value_min")]
        public int ConditionValueMin { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("condition_value_max")]
        public int ConditionValueMax { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("monster_stage_lv")]
        public int MonsterStageLv { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("passive_skill_id")]
        public int PassiveSkillId { get; set; }

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("target_passive_skill_id")]
        public int TargetPassiveSkillId { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("gimmickobject_lv_control")]
        public int GimmickObjectLvControl { get; set; }
    }

    /// <summary>
    /// Monster skill data from MonsterSkillTable
    /// </summary>
    [MemoryPackable]
    public partial class MonsterSkillData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name_localkey")]
        public string? NameKey { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("description_localkey")]
        public string? DescriptionKey { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("skill_icon")]
        public string SkillIcon { get; set; } = string.Empty;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("skill_ani_number")]
        public string AnimationNumber { get; set; } = string.Empty;

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("weapon_type")]
        public string WeaponType { get; set; } = string.Empty;

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("prefer_target")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PreferTarget PreferTarget { get; set; } = PreferTarget.None;

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("show_lock_on")]
        public bool ShowLockOn { get; set; }

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("attack_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttackType AttackType { get; set; } = AttackType.None;

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("fire_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FireType FireType { get; set; } = FireType.None;

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("casting_time")]
        public int CastingTime { get; set; }

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("break_object")]
        public string[] BreakObjects { get; set; } = [];

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("break_object_hp_raito")]
        public int BreakObjectHpRatio { get; set; }

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("skill_value_type_01")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ValueType SkillValueType1 { get; set; } = ValueType.None;

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("skill_value_01")]
        public int SkillValue1 { get; set; }

        [MemoryPackOrder(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("skill_value_type_02")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ValueType SkillValueType2 { get; set; } = ValueType.None;

        [MemoryPackOrder(16)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("skill_value_02")]
        public int SkillValue2 { get; set; }

        [MemoryPackOrder(17)]
        [JsonPropertyOrder(17)]
        [JsonPropertyName("shot_count")]
        public int ShotCount { get; set; }

        [MemoryPackOrder(18)]
        [JsonPropertyOrder(18)]
        [JsonPropertyName("delay_time")]
        public int DelayTime { get; set; }

        [MemoryPackOrder(19)]
        [JsonPropertyOrder(19)]
        [JsonPropertyName("shot_timing")]
        public string ShotTiming { get; set; } = "None";

        [MemoryPackOrder(20)]
        [JsonPropertyOrder(20)]
        [JsonPropertyName("penetration")]
        public int Penetration { get; set; }

        [MemoryPackOrder(21)]
        [JsonPropertyOrder(21)]
        [JsonPropertyName("projectile_speed")]
        public int ProjectileSpeed { get; set; }

        [MemoryPackOrder(22)]
        [JsonPropertyOrder(22)]
        [JsonPropertyName("projectile_hp_ratio")]
        public int ProjectileHpRatio { get; set; }

        [MemoryPackOrder(23)]
        [JsonPropertyOrder(23)]
        [JsonPropertyName("projectile_radius_object")]
        public int ProjectileRadiusObject { get; set; }

        [MemoryPackOrder(24)]
        [JsonPropertyOrder(24)]
        [JsonPropertyName("projectile_radius")]
        public int ProjectileRadius { get; set; }

        [MemoryPackOrder(25)]
        [JsonPropertyOrder(25)]
        [JsonPropertyName("spot_explosion_range")]
        public int ExplosionRange { get; set; }

        [MemoryPackOrder(26)]
        [JsonPropertyOrder(26)]
        [JsonPropertyName("is_destroyable_projectile")]
        public bool IsDestroyableProjectile { get; set; }

        [MemoryPackOrder(27)]
        [JsonPropertyOrder(27)]
        [JsonPropertyName("relate_anim")]
        public bool RelateAnim { get; set; }

        [MemoryPackOrder(28)]
        [JsonPropertyOrder(28)]
        [JsonPropertyName("deceleration_rate")]
        public int DecelerationRate { get; set; }

        [MemoryPackOrder(29)]
        [JsonPropertyOrder(29)]
        [JsonPropertyName("target_character_ratio")]
        public int TargetCharacterRatio { get; set; }

        [MemoryPackOrder(30)]
        [JsonPropertyOrder(30)]
        [JsonPropertyName("target_cover_ratio")]
        public int TargetCoverRatio { get; set; }

        [MemoryPackOrder(31)]
        [JsonPropertyOrder(31)]
        [JsonPropertyName("target_nothing_ratio")]
        public int TargetNothingRatio { get; set; }

        [MemoryPackOrder(32)]
        [JsonPropertyOrder(32)]
        [JsonPropertyName("calling_group_id")]
        public int CallingGroupId { get; set; }

        [MemoryPackOrder(33)]
        [JsonPropertyOrder(33)]
        [JsonPropertyName("target_count")]
        public int TargetCount { get; set; }

        [MemoryPackOrder(34)]
        [JsonPropertyOrder(34)]
        [JsonPropertyName("object_resource")]
        public string[] ObjectResources { get; set; } = [];

        [MemoryPackOrder(35)]
        [JsonPropertyOrder(35)]
        [JsonPropertyName("object_position_type")]
        public string ObjectPositionType { get; set; } = "None";

        [MemoryPackOrder(36)]
        [JsonPropertyOrder(36)]
        [JsonPropertyName("object_position")]
        public double[] ObjectPosition { get; set; } = [0.0, 0.0, 0.0];

        [MemoryPackOrder(37)]
        [JsonPropertyOrder(37)]
        [JsonPropertyName("is_using_timeline")]
        public bool IsUsingTimeline { get; set; }

        [MemoryPackOrder(38)]
        [JsonPropertyOrder(38)]
        [JsonPropertyName("control_gauge")]
        public int ControlGauge { get; set; }

        [MemoryPackOrder(39)]
        [JsonPropertyOrder(39)]
        [JsonPropertyName("control_parts")]
        public string[] ControlParts { get; set; } = [];

        [MemoryPackOrder(40)]
        [JsonPropertyOrder(40)]
        [JsonPropertyName("weapon_object_enum")]
        public string? WeaponObjectEnum { get; set; }

        [MemoryPackOrder(41)]
        [JsonPropertyOrder(41)]
        [JsonPropertyName("linked_parts")]
        public string? LinkedParts { get; set; }

        [MemoryPackOrder(42)]
        [JsonPropertyOrder(42)]
        [JsonPropertyName("cancel_type")]
        public string? CancelType { get; set; }

        [MemoryPackOrder(43)]
        [JsonPropertyOrder(43)]
        [JsonPropertyName("move_object")]
        public string[] MoveObject { get; set; } = [];
    }
}