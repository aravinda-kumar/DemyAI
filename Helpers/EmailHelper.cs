namespace DemyAI.Helpers;

public class EmailHelper {

    public static async Task OpenEmailClientAsync(string[] recipients) {

        var message = new EmailMessage {
            To = new List<string>(recipients),
            Subject = "Subject",
            Body = "Body of the email"
        };
        await Email.ComposeAsync(message);
    }
}