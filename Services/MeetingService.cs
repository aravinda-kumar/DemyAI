

namespace DemyAI.Services;

public class MeetingService(IHttpService httpService) : IMeetingService {

    public async Task<string> CreateMeetingAsync(string roomName, MeetingOptions meetingOptions, string authToken) {

        string apiUrl = "https://api.daily.co/v1/rooms/";

        try {

            var room = new Room { Name = roomName, Privacy = "public", meetingOptions = meetingOptions };

            var json = JsonSerializer.Serialize(room);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpService.PostAsync(apiUrl, content, authToken);

            if(response != null && response.IsSuccessStatusCode) {

                var responseContent = await response.Content.ReadFromJsonAsync<RoomResponse>();
                return responseContent!.url;

            } else {
                var statusCode = response?.StatusCode;
                Console.WriteLine($"Failed to create room. Status code: {statusCode}");
                return string.Empty;
            }

        } catch(Exception) {

            return string.Empty;

        }
    }
}
