namespace DemyAI.Models;

public class Room {

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("properties")]
    public MeetingOptions meetingOptions { get; set; }

    [JsonPropertyName("privacy")]
    public string Privacy { get; set; }

}

public class MeetingOptions {

    [JsonPropertyName("enable_people_ui")]
    public bool EnablePeopleUi { get; set; }

    [JsonPropertyName("enable_pip_ui")]
    public bool EnablePipUi { get; set; }

    [JsonPropertyName("enable_emoji_reactions")]
    public bool EnableEmojiReactions { get; set; }

    [JsonPropertyName("enable_hand_raising")]
    public bool EnableHandRaising { get; set; }

    [JsonPropertyName("enable_prejoin_ui")]
    public bool EnablePrejoinUi { get; set; }

    [JsonPropertyName("enable_noise_cancellation_ui")]
    public bool EnableNoiseCancellationUi { get; set; }

    [JsonPropertyName("enable_knocking")]
    public bool EnableKnocking { get; set; }

    [JsonPropertyName("enable_screenshare")]
    public bool EnableScreenshare { get; set; }

    [JsonPropertyName("enable_video_processing_ui")]
    public bool EnableVideoProcessingUi { get; set; }

    [JsonPropertyName("enable_chat")]
    public bool EnableChat { get; set; }

    [JsonPropertyName("start_video_off")]
    public bool StartVideoOff { get; set; }

    [JsonPropertyName("start_audio_off")]
    public bool StartAudioOff { get; set; }

    [JsonPropertyName("enable_advanced_chat")]
    public bool EnableAdvancedChat { get; set; }

    [JsonPropertyName("enable_mesh_sfu")]
    public bool EnableMeshSfu { get; set; } = true;

    [JsonPropertyName("sfu_switchover")]
    public float SfuSwitchover { get; set; } = 0.5f;

    [JsonPropertyName("experimental_optimize_large_calls")]
    public bool ExperimentalOptimizeLargeCalls { get; set; }
}

