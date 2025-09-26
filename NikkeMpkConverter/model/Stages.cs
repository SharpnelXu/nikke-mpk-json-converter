using MemoryPack;
using System.Text.Json.Serialization;

namespace NikkeMpkConverter.model
{
    /// <summary>
    /// Wave monster data
    /// </summary>
    [MemoryPackable]
    public partial class WaveMonster
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("wave_monster_id")]
        public int? MonsterId { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("spawn_type")]
        public string? SpawnType { get; set; }
    }

    /// <summary>
    /// Wave path data containing monster information
    /// </summary>
    [MemoryPackable]
    public partial class WavePathData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("wave_path")]
        public string? Path { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("wave_monster_list")]
        public WaveMonster[] MonsterList { get; set; } = [];

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("private_monster_count")]
        public int? PrivateMonsterCount { get; set; }
    }

    /// <summary>
    /// Wave data containing stage and battle information
    /// </summary>
    [MemoryPackable]
    public partial class WaveData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("stage_id")]
        public int StageId { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("group_id")]
        public string GroupId { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("spot_mod")]
        public string SpotMod { get; set; } = string.Empty;

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("battle_time")]
        public int BattleTime { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("monster_count")]
        public int MonsterCount { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("use_intro_scene")]
        public bool UseIntroScene { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("wave_repeat")]
        public bool WaveRepeat { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("point_data")]
        public string PointData { get; set; } = string.Empty;

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("point_data_fly")]
        public string PointDataFly { get; set; } = string.Empty;

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("background_name")]
        public string BackgroundName { get; set; } = string.Empty;

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("theme")]
        public string Theme { get; set; } = string.Empty;

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("theme_time")]
        public string ThemeTime { get; set; } = string.Empty;

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("stage_info_bg")]
        public string StageInfoBg { get; set; } = string.Empty;

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("target_list")]
        public int[] TargetList { get; set; } = [];

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("wave_data")]
        public WavePathData[] WavePathData { get; set; } = [];

        [MemoryPackOrder(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("close_monster_count")]
        public int CloseMonsterCount { get; set; }

        [MemoryPackOrder(16)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("mid_monster_count")]
        public int MidMonsterCount { get; set; }

        [MemoryPackOrder(17)]
        [JsonPropertyOrder(17)]
        [JsonPropertyName("far_monster_count")]
        public int FarMonsterCount { get; set; }

        [MemoryPackOrder(18)]
        [JsonPropertyOrder(18)]
        [JsonPropertyName("mod_value")]
        public int? ModValue { get; set; }

        [MemoryPackOrder(19)]
        [JsonPropertyOrder(19)]
        [JsonPropertyName("ui_theme")]
        public string? UiTheme { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuickBattleType
    {
        None = 0,
        StageClear = 1
    }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SoloRaidDifficultyType
    {
        Common = 1,
        Trial = 2
    }

    /// <summary>
    /// Solo raid wave data from SoloRaidPresetTable
    /// </summary>
    [MemoryPackable]
    public partial class SoloRaidWaveData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("preset_group_id")]
        public int PresetGroupId { get; set; }

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("difficulty_type")]
        public SoloRaidDifficultyType DifficultyType { get; set; } = SoloRaidDifficultyType.Common;

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("quick_battle_type")]
        public QuickBattleType QuickBattleType { get; set; } = QuickBattleType.None;

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("character_lv")]
        public int CharacterLevel { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("wave_open_condition")]
        public int WaveOpenCondition { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("wave_order")]
        public int WaveOrder { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("wave")]
        public int Wave { get; set; }

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("monster_stage_lv")]
        public int MonsterStageLevel { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("monster_stage_lv_change_group")]
        public int MonsterStageLevelChangeGroup { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("dynamic_object_stage_lv")]
        public int DynamicObjectStageLevel { get; set; }

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("cover_stage_lv")]
        public int CoverStageLevel { get; set; }

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("spot_autocontrol")]
        public bool SpotAutocontrol { get; set; }

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("wave_name")]
        public string WaveName { get; set; } = string.Empty;

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("wave_description")]
        public string WaveDescription { get; set; } = string.Empty;

        [MemoryPackOrder(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("monster_image_si")]
        public string MonsterImageSi { get; set; } = string.Empty;

        [MemoryPackOrder(16)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("monster_image")]
        public string MonsterImage { get; set; } = string.Empty;

        [MemoryPackOrder(17)]
        [JsonPropertyOrder(17)]
        [JsonPropertyName("first_clear_reward_id")]
        public int FirstClearRewardId { get; set; }

        [MemoryPackOrder(18)]
        [JsonPropertyOrder(18)]
        [JsonPropertyName("reward_id")]
        public int RewardId { get; set; }
    }

    /// <summary>
    /// Multiplayer raid data from MultiRaidTable
    /// </summary>
    [MemoryPackable]
    public partial class MultiplayerRaidData
    {
        [MemoryPackOrder(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [MemoryPackOrder(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("player_count")]
        public int PlayerCount { get; set; }

        [MemoryPackOrder(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("character_select_time_limit")]
        public int CharacterSelectTimeLimit { get; set; }

        [MemoryPackOrder(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("character_lv")]
        public int CharacterLevel { get; set; }

        [MemoryPackOrder(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("stage_level")]
        public int StageLevel { get; set; }

        [MemoryPackOrder(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("monster_stage_lv")]
        public int MonsterStageLevel { get; set; }

        [MemoryPackOrder(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("dynamic_object_stage_lv")]
        public int DynamicObjectStageLevel { get; set; }

        [MemoryPackOrder(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("cover_stage_lv")]
        public int CoverStageLevel { get; set; }

        [MemoryPackOrder(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("monster_stage_lv_change_group")]
        public int MonsterStageLevelChangeGroup { get; set; }

        [MemoryPackOrder(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("spot_id")]
        public int SpotId { get; set; }

        [MemoryPackOrder(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("monster_stage_lv_change_group_easy")]
        public int MonsterStageLvChangeGroupEasy { get; set; }

        [MemoryPackOrder(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("spot_id_easy")]
        public int SpotIdEasy { get; set; }

        [MemoryPackOrder(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("condition_reward_group")]
        public int ConditionRewardGroup { get; set; }

        [MemoryPackOrder(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("reward_limit_count")]
        public int RewardLimitCount { get; set; }

        [MemoryPackOrder(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("rank_condition_reward_group")]
        public int RankConditionRewardGroup { get; set; }
    }
}