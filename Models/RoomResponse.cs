namespace DemyAI.Models;

public class Config {

    public int max_participants { get; set; }

    public int nbf { get; set; }

    public int exp { get; set; }

    public bool start_video_off { get; set; }

    public string? enable_recording { get; set; }
}

public class RoomResponse {

    public string? id { get; set; }

    public string? name { get; set; }

    public bool api_created { get; set; }

    public string? privacy { get; set; }

    public string? url { get; set; }

    public DateTime created_at { get; set; }

    public Config? config { get; set; }
}
