namespace DemyAI.Models {

    public class Participant {

        public object user_id { get; set; }

        public string participant_id { get; set; }

        public string user_name { get; set; }

        public int join_time { get; set; }

        public int duration { get; set; }
    }

    public class Datum {

        public string id { get; set; }

        public string room { get; set; }

        public int start_time { get; set; }

        public int duration { get; set; }

        public bool ongoing { get; set; }

        public int max_participants { get; set; }

        public IList<Participant> participants { get; set; }
    }

    public class MeetingData {

        public string roomName { get; set; }

        public int total_count { get; set; }

        public IList<Datum> data { get; set; }
    }
}
