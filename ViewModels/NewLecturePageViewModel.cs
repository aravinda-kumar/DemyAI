namespace DemyAI.ViewModels;

public partial class NewLecturePageViewModel(IAppService appService, IHttpService httpService,
    IDataService<DemyUser> dataService, IMeetingService meetingService) : BaseViewModel {

    [ObservableProperty]
    bool isMeetingPopUpOpen;

    [ObservableProperty]
    string? roomName;

    [ObservableProperty]
    string? roomURL;


    //private async Task GetStudents() {

    //    Student.Clear();

    //    var students = await dataService.GetByRole(nameof(Roles.Student));

    //    foreach(var student in students) {

    //        Student.Add(student);
    //    }

    //}

    [RelayCommand]
    async Task StartLecture() {

        if (string.IsNullOrEmpty(RoomName)) {

            var answer = await appService.DisplayAlert("Warning",
                "It looks like the name for the lecture is empty," +
                "do you want us to crate a name for you",
                "Yes", "No");

            if (answer) {
                RoomName = Generators.GenerateRandomName(6);
            } else {
                return;
            }

        } else {
            RoomName = RoomName!.Replace(" ", string.Empty);
        }

        var meetingOptions = new MeetingOptions {
            EnableAdvancedChat = true,
            EnableEmojiReactions = true,
            EnableNoiseCancellationUI = true,
            EnableHandRaising = true,
            EnablePrejoinUI = true,
            EnableScreenshare = true,
            EnableVideoProcessingUI = true,
            EnableChat = true,
            EnableNetworkUI = true,

            // Set other meeting option properties as needed
        };


        RoomURL = await meetingService.CreateMeetingAsync(
            RoomName!, meetingOptions, Constants.DAILY_AUTH_TOKEN);

        if (!string.IsNullOrEmpty(RoomURL)) {

            var roomPresence = await meetingService.GetMeetingPresence(
                Constants.DAILY_AUTH_TOKEN,
                RoomName!);

            await dataService.AddAsync(Constants.MEETINGS, roomPresence, RoomName);
        }


        IsMeetingPopUpOpen = true;
    }

    //if(!string.IsNullOrEmpty(RoomURL)) {
    //    IsMeetingLinkPopUpOpen = true;
    //    if(IsMeetingLinkPopUpOpen) {
    //        if(DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) {
    //            await EmailHelper.SendEmail(Invited, RoomName.Trim(), databaseUser, null);
    //        }
    //    }
    //}


    [RelayCommand]
    async Task ShareURLLink() {

        if (!string.IsNullOrEmpty(RoomURL)) {
            await Share.Default.RequestAsync(new ShareTextRequest {
                Text = $"This is the meeting name: \n\n{RoomName}",
            });
        }
    }

    [RelayCommand]
    async Task CopyLink() {

        if (!string.IsNullOrEmpty(RoomURL)) {
            await Clipboard.Default.SetTextAsync(RoomName);
            await appService.DisplayToast("Meeting name has been copied",
                ToastDuration.Short,
                16);
        }
    }
}
