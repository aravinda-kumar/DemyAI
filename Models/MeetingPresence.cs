namespace DemyAI.Models;

public class Datum {
    public string room { get; set; }
    public string id { get; set; }
    public string userId { get; set; }
    public string userName { get; set; }
    public DateTime joinTime { get; set; }
    public int duration { get; set; }
}

public class MeetingPresence {
    public int total_count { get; set; }
    public IList<Datum> data { get; set; }
}