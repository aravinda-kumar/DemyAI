using System.Net.Mail;

using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;

public partial class NewLecturePageViewModel(IAppService appService, IDataService<User> dataService, IMeetingService meetingService,
    IAuthenticationService authenticationService) : BaseViewModel {

    public ObservableCollection<User> Users { get; set; } = [];

    public ObservableCollection<User> Invited { get; set; } = [];

    [ObservableProperty]
    string? roomName;

    [RelayCommand]
    async Task Appearing() {
        await GetStudents();
    }

    private async Task GetStudents() {

        Users.Clear();

        var data = await dataService.GetByRole<User>("Users", Roles.Student.ToString());

        foreach(var filterUser in data) {

            Users.Add(filterUser);
        }
    }

    [RelayCommand]
    void HandleCheckBox(User user) {

        if(user.IsParticipant) {
            Invited.Add(user);
        } else {
            Invited.Remove(user);
        }


    }

    [RelayCommand]
    async Task StartMeeting() {

        if(string.IsNullOrEmpty(RoomName)) {
            await appService.DisplayAlert("Error", "You cannot create a Lecture without a name", "OK");
            return;
        }

        var loogedUser = await authenticationService.GetLoggedInUser();

        var teacher = await dataService.GetByUidAsync<User>("Users", loogedUser!.Uid);

        var meetingOptions = new MeetingOptions {
            EnableAdvancedChat = true,
            EnableEmojiReactions = true,
            EnableNoiseCancellationUi = true,
            EnableHandRaising = true,
            EnablePrejoinUi = true,
            EnablePipUi = true,
            EnableScreenshare = true,
            EnableVideoProcessingUi = true,
            EnablePeopleUi = true,
            EnableChat = true
            // Set other meeting option properties as needed
        };

        try {
            var roomURL = await meetingService.CreateMeetingAsync(RoomName, meetingOptions, Constants.DAILY);

            foreach(var userInvited in Invited) {
                string userEmail = userInvited.Email;
                await SendEmail(userEmail, roomURL, teacher);
            }

        } catch(Exception ex) {
            // Handle any exceptions that might occur during the meeting creation
            Console.WriteLine($"Error creating meeting: {ex.Message}");
        }
    }

    private async Task SendEmail(string userEmail, string MeetingLink, User? teacher) {
        try {

            var mail = new MailMessage("eduardogr88@gmail.com", userEmail) {
                Subject = "Meeting Link",
                IsBodyHtml = true
            };

            var body = HttmlGenerator.GenerateHttmlTemplate(RoomName!, MeetingLink, teacher!.Name);

            mail.Body = body;

            var smtpClient = new SmtpClient("smtp.gmail.com") {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("eduardogr88@gmail.com", "svzq gwda mnwc rwvz"),
                Port = 587,
            };

            await smtpClient.SendMailAsync(mail);

            await appService.DisplayAlert("Success", "Email sent successfully", "OK");

        } catch(Exception e) {

            await appService.DisplayAlert("Eroor", e.Message, "OK");
        }
    }
}
