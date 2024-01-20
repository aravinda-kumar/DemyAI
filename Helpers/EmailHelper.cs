using Mailjet.Client.Resources;
using Mailjet.Client;

using System.Net.Mail;

namespace DemyAI.Helpers;

public class EmailHelper {

    private static string GenerateHttmlTemplate(string roomName, string meetingLink, string userName, DateTime? dateTime = null) {

        string htmlBody = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <style>
                /* CSS for the button */
                .button {{
                    background-color: #5C3E88; /* Button background color */
                    color: white; /* Text color */
                    text-decoration: none;
                    padding: 10px 20px; /* Padding around text */
                    border-radius: 5px; /* Rounded corners */
                    display: inline-block;
                }}
            </style>
        </head>
        <body>
            <p>Here are the meeting details:</p>
            <br> <!-- Add a line break -->
            <p><strong>Meeting Name:</strong> {roomName}</p>
            <p><strong>Teacher Name:</strong> {userName}</p>
            <p>Click the button below to join the meeting:</p>
            <p><a class='button' href='{meetingLink}'>Join</a></p>";

        if(dateTime.HasValue) {
            htmlBody += $@"
            <p><strong>Date and Time:</strong> {dateTime.Value}</p>";
            // You can format the DateTime value as needed, e.g., dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
        }

        htmlBody += @"
        </body>
        </html>";

        return htmlBody;

    }

    public static async Task SendEmail(string userEmail, string roomName, Models.User? user, string meetingLink, DateTime? dateTimeMeeting) {

        var client = new MailjetClient(Constants.MAILJETAPIKEY, Constants.MAILJETSECRETKEY);

        var mail = new MailMessage("eduardogr88@gmail.com", userEmail) {
            Subject = "DemyIA meeting",
            IsBodyHtml = true
        };

        var body = GenerateHttmlTemplate(roomName, meetingLink, user!.Name, dateTimeMeeting);

        mail.Body = body;

        var smtpClient = new SmtpClient("smtp.gmail.com") {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new System.Net.NetworkCredential("eduardogr88@gmail.com", "svzq gwda mnwc rwvz"),
            Port = 587,
            DeliveryMethod = SmtpDeliveryMethod.Network
        };

        await smtpClient.SendMailAsync(mail);

    }
}
