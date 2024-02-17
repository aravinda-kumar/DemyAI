using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;

public partial class NewLecturePageViewModel(IAppService appService, IHttpService httpService,
    IDataService<User> dataService, IMeetingService meetingService) : BaseViewModel {

    public ObservableCollection<User> Users { get; set; } = [];

    public ObservableCollection<User> Invited { get; set; } = [];

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

    private const string UID = "Uid";

    [RelayCommand]
    async Task Appearing() {

        await GetStudents();
        await GetTimeZones();
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

        var zones = await httpService.GetAsync<List<string>>("https://www.timeapi.io/api/TimeZone/AvailableTimeZones");

        for(int i = 0; i <= zones!.Count - 1; ++i) {
            TimeZones.Add(i, zones[i]);
        }
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
            if(!Invited.Contains(user)) {
                Invited.Add(user);
            }
        } else {
            Invited.Remove(user);
        }

    }

    [RelayCommand]
    async Task StartMeeting() {

        if(string.IsNullOrEmpty(RoomName)) {
            await appService.DisplayAlert("Error", "The room name cannot be empty", "OK");
            return;
        }

        RoomName = RoomName.Replace(" ", string.Empty);

        var currUserUID = await SecureStorage.GetAsync("CurrentUser");

        var databaseUser = await dataService.GetByUidAsync<User>("Users", currUserUID!);

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


        RoomURL = await meetingService.CreateMeetingAsync(RoomName, meetingOptions, Constants.DAILY_AUTH_TOKEN);

        if(!string.IsNullOrEmpty(RoomURL)) {
            List<string> studentNames = [];

            foreach(var item in Invited) {
                studentNames.Add(item.Name!);
            }

            var meeting = new Meeting() { Name = RoomName, StudentList = studentNames, Uid = string.Empty };

            var uid = await dataService.AddAsync("Meetings", meeting);

            await dataService.UpdateAsync<Meeting>("Meetings", uid, uid, UID);

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


    }

    [RelayCommand]
    async Task CopyRoomURLAsync() {

        if(!string.IsNullOrEmpty(RoomURL)) {
            await Share.Default.RequestAsync(new ShareTextRequest {
                Text = $"This is the meeting URL \n\n{RoomURL}",
            });
        }
    }
}
