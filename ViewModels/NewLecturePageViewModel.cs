namespace DemyAI.ViewModels;

public partial class NewLecturePageViewModel(IAppService appService, IHttpService httpService,
    IDataService<DemyUser> dataService, IMeetingService meetingService) : BaseViewModel {

    public ObservableCollection<DemyUser> Student { get; set; } = [];

    public Dictionary<int, string> TimeZones { get; set; } = [];

    [ObservableProperty]
    DateTime selectedDateTime;

    [ObservableProperty]
    bool isMeetingLinkPopUpOpen;

    [ObservableProperty]
    bool isDateTimeSelected;

    [ObservableProperty]
    string? roomName;

    [ObservableProperty]
    string? roomURL;

    [RelayCommand]
    async Task Appearing() {


        await Task.Delay(1000);
        await GetStudents();
    }

    [RelayCommand]
    void OpenPicker(SfDateTimePicker picker) {

        if(picker != null) {
            picker.IsOpen = true;
        }
    }

    [RelayCommand]
    void DateTimeOkButton(SfDateTimePicker picker) {

        if(picker != null) {
            IsDateTimeSelected = true;
            picker.IsOpen = false;
        }
    }

    [RelayCommand]
    void DateTimeCanelButton(SfDateTimePicker picker) {
        if(picker != null) {
            picker.IsOpen = false;
        }
    }

    private async Task GetTimeZones() {

        var zones =
            await httpService.GetAsync<List<string>>(
                "https://www.timeapi.io/api/TimeZone/AvailableTimeZones");

        for(int i = 0; i <= zones!.Count - 1; ++i) {
            TimeZones.Add(i, zones[i]);
        }
    }

    private async Task GetStudents() {

        Student.Clear();

        var students = await dataService.GetByRole(nameof(Roles.Student));

        foreach(var student in students) {

            Student.Add(student);
        }

    }

    [RelayCommand]
    async Task StartMeeting() {

        RoomName = RoomName?.Replace(" ", string.Empty);

        var currentUserEmail = await SecureStorage.GetAsync("CurrentUser");

        var meetingOptions = new MeetingOptions {
            EnableAdvancedChat = true,
            EnableEmojiReactions = true,
            EnableNoiseCancellationUi = true,
            EnableHandRaising = true,
            EnablePrejoinUi = true,
            EnablePipUi = true,
            EnableScreenshare = true,
            EnableVideoProcessingUi = true,
            EnablePeopleUi = false,
            EnableChat = true,
            // Set other meeting option properties as needed
        };


        RoomURL = await meetingService.CreateMeetingAsync(RoomName!, meetingOptions, Constants.DAILY_AUTH_TOKEN);

        // We are creating dummy meeting, so we can update it later 

        MeetingData dummyData = new() { roomName = RoomName! };

        await dataService.AddAsync("Meetings", dummyData, RoomName);

        IsMeetingLinkPopUpOpen = true;
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

        if(!string.IsNullOrEmpty(RoomURL)) {
            await Share.Default.RequestAsync(new ShareTextRequest {
                Text = $"This is the meeting URL \n\n{RoomURL}",
            });
        }
    }

    [RelayCommand]
    async Task CopyLink() {

        if(!string.IsNullOrEmpty(RoomURL)) {
            await Clipboard.Default.SetTextAsync(RoomURL);
        }
    }
}
