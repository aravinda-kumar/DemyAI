namespace DemyAI.Interfaces;
public interface IMeetingService {

    /// <summary>
    /// This interface will create a meeting on Daily.co
    /// </summary>
    /// <param name="title"> Title of the meeting </param>
    /// <returns> Returns the roomUrl of the meeting </returns>

    Task<string> CreateMeetingAsync(string title, MeetingOptions meetingOptions, string authToken);


    Task<MeetingData> GetMeetingData(string roomName, string authToken);


}
