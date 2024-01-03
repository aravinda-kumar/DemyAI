namespace DemyAI.Helpers;
public class HttmlGenerator {

    public static string GenerateHttmlTemplate(string roomName, string meetingLink, string teacherName, DateTime? meetingDateTime = null) {

        string htmlBody = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
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
                <p><strong>Teacher Name:</strong> {teacherName}</p>
                <p>Click the button below to join the meeting:</p>
                <p><a class='button' href='{meetingLink}'>Join</a></p>
            </body>
            </html>";

        return htmlBody;
    }
}
