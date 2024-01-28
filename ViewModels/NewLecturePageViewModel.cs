using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;

public partial class NewLecturePageViewModel(IAppService appService, IHttpService httpService,
    IDataService<User> dataService, IMeetingService meetingService,
    IAuthenticationService authenticationService) : BaseViewModel {

    public ObservableCollection<User> Users { get; set; } = [];

    public ObservableCollection<User> Invited { get; set; } = [];

    public ObservableCollection<string> TimeZones { get; set; } = [];

    [ObservableProperty]
    DateTime selectedDateTime;

    [ObservableProperty]
    bool isDateTimeSelected;

    [ObservableProperty]
    string? roomName;

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

        TimeZones.Clear();
        foreach(var item in zones!) {
            TimeZones.Add(item);
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

        var loogedUser = await authenticationService.GetLoggedInUser();

        var databaseUser = await dataService.GetByUidAsync<User>("Users", loogedUser!.Uid);

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

        string? roomURL = null;

        try {
            roomURL = await meetingService.CreateMeetingAsync(RoomName, meetingOptions, Constants.DAILY);
        } catch(Exception ex) {
            // Handle any exceptions that might occur during the meeting creation
            await appService.DisplayAlert("Error", $"Error creating meeting: {ex.Message}", "OK");
        }

        if(DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) {
            await EmailHelper.SendEmail(Invited, RoomName.Trim(), databaseUser, null);
        } else if(DeviceInfo.Platform == DevicePlatform.WinUI) {
            await Clipboard.Default.SetTextAsync(roomURL);
        }

        //await appService.DisplayToast("the meeting url has been copied o the clipboard", ToastDuration.Short, 18);


    }
}
