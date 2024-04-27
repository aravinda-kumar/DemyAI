namespace DemyAI.Models;

public class MeetingRoom {

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("properties")]
    public MeetingOptions meetingOptions { get; set; }

    [JsonPropertyName("privacy")]
    public string Privacy { get; set; }

}

public class MeetingOptions {
    public int Nbf { get; set; } // Unix timestamp (seconds since the epoch)
    public int Exp { get; set; } // Unix timestamp (seconds since the epoch)
    public int MaxParticipants { get; set; } // Maximum number of participants allowed in the room
    public bool EnablePeopleUI { get; set; } // Determines if Daily Prebuilt displays the People UI
    public bool EnablePipUI { get; set; } // Sets whether the room can use Daily Prebuilt's Picture in Picture controls
    public bool EnableEmojiReactions { get; set; } // Determines if Daily Prebuilt displays the Emoji Reactions UI
    public bool EnableHandRaising { get; set; } // Sets whether the participants in the room can use Daily Prebuilt's hand raising controls
    public bool EnablePrejoinUI { get; set; } // Determines whether participants enter a waiting room with a camera, mic, and browser check before joining a call
    public bool EnableLiveCaptionsUI { get; set; } // Sets whether participants in a room see a closed captions button in their Daily Prebuilt call tray
    public bool EnableNetworkUI { get; set; } // Determines whether the network button, and the network panel it reveals on click, appears in this room
    public bool EnableNoiseCancellationUI { get; set; } // Determines whether Daily Prebuilt displays noise cancellation controls
    public bool EnableBreakoutRooms { get; set; } // Sets whether Daily Prebuilt’s breakout rooms feature is enabled
    public bool EnableKnocking { get; set; } // Turns on a lobby experience for private rooms
    public bool EnableScreenshare { get; set; } // Sets whether users in a room can screen share during a session
    public bool EnableVideoProcessingUI { get; set; } // Determines whether Daily Prebuilt displays background blur controls
    public bool EnableChat { get; set; } // Adds chat to Daily video calls
    public bool StartVideoOff { get; set; } // Disables the default behavior of automatically turning on a participant's camera
    public bool StartAudioOff { get; set; } // Disables the default behavior of automatically turning on a participant's microphone
    public bool OwnerOnlyBroadcast { get; set; } // In Daily Prebuilt, only the meeting owners will be able to turn on camera, unmute mic, and share screen
    public string EnableRecording { get; set; } // Enables recording options
    public bool EjectAtRoomExp { get; set; } // Ends the meeting by kicking everyone out at room exp time
    public int EjectAfterElapsed { get; set; } // Ejects a meeting participant this many seconds after the participant joins the meeting
    public bool EnableAdvancedChat { get; set; } // Gives end users a richer chat experience
    public bool EnableHiddenParticipants { get; set; } // When enabled, non-owner users join a meeting with a hidden presence
    public bool EnableMeshSfu { get; set; } // Configures a room to use multiple SFUs for a call's media
    public double SfuSwitchover { get; set; } // Dictates the participant count after which room topology automatically switches
    public bool EnableAdaptiveSimulcast { get; set; } // Configures a domain or room to use Daily Adaptive Bitrate
    public bool ExperimentalOptimizeLargeCalls { get; set; } // Enables Daily Prebuilt to support group calls of up to 1,000 participants
    public string Lang { get; set; } // The default language of the Daily prebuilt video call UI
    public string MeetingJoinHook { get; set; } // Sets a URL that will receive a webhook when a user joins a room
    public string Geo { get; set; } // Configures the AWS region for hosting the call
    public string RtmpGeo { get; set; } // Selects the region where an RTMP stream should originate
    public bool DisableRtmpGeoFallback { get; set; } // Disables the fallback behavior of rtmp_geo
    public RecordingsBucket RecordingsBucket { get; set; } // Configures an S3 bucket in which to store recordings
    public bool EnableTerseLogging { get; set; } // Reduces the volume of log messages
    public AutoTranscriptionSettings AutoTranscriptionSettings { get; set; } // Options to use when auto_start_transcription is true
    public bool EnableTranscriptionStorage { get; set; } // Live transcriptions generated can be saved as WebVTT
    public TranscriptionBucket TranscriptionBucket { get; set; } // Configures an S3 bucket in which to store transcriptions
    public string RecordingsTemplate { get; set; } // Defines the template for cloud recordings file names
}

public class RecordingsBucket {
    public string BucketName { get; set; }
    public string BucketRegion { get; set; }
    public string AssumeRoleArn { get; set; }
    public bool AllowApiAccess { get; set; }
    public bool AllowStreamingFromBucket { get; set; }
}

public class AutoTranscriptionSettings {
    public bool EnableTranscriptionStorage { get; set; }
}

public class TranscriptionBucket {
    public string BucketName { get; set; }
    public string BucketRegion { get; set; }
    public string AssumeRoleArn { get; set; }
    public bool AllowApiAccess { get; set; }
}