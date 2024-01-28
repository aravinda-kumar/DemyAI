using User = DemyAI.Models.User;

namespace DemyAI.Helpers;

public class EmailHelper {

    private static string GenerateHttmlTemplate(string roomName, string meetingLink, string userName, DateTime? dateTime = null) {

        return $@"
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
                <p><a class='button' href='{meetingLink}'>Join</a></p>
            </body>
            </html>";
    }

    public static async Task SendEmail(ObservableCollection<User> users, string roomName, User? user, DateTime? dateTimeMeeting) {

        try {
            var meetingLink = string.Empty;
            using(var smtpClient = new SmtpClient("smtp.gmail.com")) {
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.EMAIL, Constants.APP_PASSWORD);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;


                //if(DeviceInfo.Platform == DevicePlatform.WinUI) {
                //    string protocol = "demy-ia";
                //    meetingLink = $"{protocol}://{roomName}";
                //} else {
                //    meetingLink = $"{Constants.BASETTING_URL}{roomName}";
                //}

                Console.WriteLine(meetingLink);

                foreach(var recipient in users) {
                    var mail = new MailMessage() {
                        From = new MailAddress(Constants.EMAIL),
                        Subject = "DemyIA meeting",
                        IsBodyHtml = true,
                    };

                    var body = GenerateHttmlTemplate(roomName, meetingLink, user!.Name, dateTimeMeeting);

                    mail.Body = body;

                    // Add the recipient to the message
                    mail.To.Add(recipient.Email);

                    // Send the email asynchronously and await the task
                    smtpClient.Send(mail);
                }
            }

            Console.WriteLine("Email sent successfully to the SMTP server.");

        } catch(Exception e) {
            await Console.Out.WriteLineAsync(e.Message);
        }
    }
}