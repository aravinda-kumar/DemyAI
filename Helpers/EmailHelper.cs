namespace DemyAI.Helpers;

public class EmailHelper {

    public static async Task OpenEmailClientAsync(string email) {

        var message = new EmailMessage {
            To = { email },
            Subject = "Subject",
            Body = "Body of the email"
        };
        await Email.ComposeAsync(message);
    }
}