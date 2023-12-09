namespace DemyAI.Models {
    public class MeetingOptions {
        public string Name { get; set; }

        public string Privacy { get; set; }

        public int Nbf { get; set; }

        public int Exp { get; set; }

        public int MaxParticipants { get; set; }

        public bool EnablePeopleUi { get; set; }

        public bool EnablePipUi { get; set; }

        public bool EnableEmojiReactions { get; set; }

        public bool EnableHandRaising { get; set; }

        public bool EnablePrejoinUi { get; set; }

        public bool EnableNetworkUi { get; set; }

        public bool EnableNoiseCancellationUi { get; set; }

        public bool EnableBreakoutRooms { get; set; }

        public bool EnableKnocking { get; set; }

        public bool EnableScreenshare { get; set; }

        public bool EnableVideoProcessingUi { get; set; }

        public bool EnableChat { get; set; }

        public bool StartVideoOff { get; set; }

        public bool StartAudioOff { get; set; }

        public bool OwnerOnlyBroadcast { get; set; }

        public string EnableRecording { get; set; }

        public bool EjectAtRoomExp { get; set; }

        public int EjectAfterElapsed { get; set; }

        public bool EnableAdvancedChat { get; set; }

        public bool EnableHiddenParticipants { get; set; }

        public bool EnableMeshSfu { get; set; }

        public int SfuSwitchover { get; set; }

        public bool ExperimentalOptimizeLargeCalls { get; set; }

        public string Lang { get; set; }

        public string MeetingJoinHook { get; set; }

        public string SignalingImp { get; set; }

        public string Geo { get; set; }

        public string RtmpGeo { get; set; }

        public RecordingsBucket RecordingsBucket { get; set; }

        public bool EnableTerseLogging { get; set; }

        public bool EnableTranscriptionStorage { get; set; }

        public TranscriptionBucket TranscriptionBucket { get; set; }

        public string RecordingsTemplate { get; set; }

        public string[] StreamingEndpoints { get; set; }

        public MeetingOptions() {
            // Initialize default values here
        }
    }
}
