namespace DemyAI.ViewModels;

public partial class JoinMeetingPageViewModel(AppShell appShell, IHttpService httpService, IMeetingService meetingService, IAppService appService)
    : BaseViewModel {

    double currentFlyoutWith = appShell.FlyoutWidth;

    public ObservableCollection<string> names { get; set; } = [];

    [ObservableProperty]
    bool meetingSearchVibiility = true;

    [ObservableProperty]
    bool toolbarVisibility;

    [ObservableProperty]
    bool isWebViewVisible;

    [ObservableProperty]
    string? text;

    [ObservableProperty]
    string? roomName;

    [ObservableProperty]
    bool isTakeBreakTime;

    [ObservableProperty]
    string? elapsedTimeString;

    private readonly Stopwatch? stopwatch = new();

    private Timer? meetingTimer;
    private Timer? breakTimeTimer;

    private MeetingData? data;

    private Timer? apiRequestDataTimer;

    [RelayCommand]
    async Task EntryCompleted() {
        await VerifyAddressAsync(appService);
    }

    public async Task InitializeApiPolling() {
        StartMeetingApiPolling();
        await UpdateMeetingData();
    }

    private void StartMeetingApiPolling() {
        apiRequestDataTimer = new Timer(
            async state => await GetMeeetingData(),
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(30)
        );
    }

    private void StartBreakTimeTimer() {
        breakTimeTimer = new Timer(
            state => ShowAlert(new BreakTimePopUp()),
            null,
            TimeSpan.FromSeconds(30),
            Timeout.InfiniteTimeSpan);
    }


    private void StartMeetingTimer() {
        stopwatch!.Start();
        meetingTimer = new Timer(state => UpdateElapsedTime(),
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(1));
    }

    private void UpdateElapsedTime() {
        TimeSpan elapsed = stopwatch!.Elapsed;
        ElapsedTimeString = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
    }


    private async Task UpdateMeetingData() {
        if(data == null) {
            data = (MeetingData?)await meetingService.GetMeetingData(RoomName, Constants.DAILY_AUTH_TOKEN);
            await GetMeeetingData();
        }
; // Trigger data processing
    }

    private async Task VerifyAddressAsync(IAppService appService) {
        if(Text is not null && Text!.Contains("demy-ia")) {
            GotoSite();
        } else {
            await appService.DisplayAlert("Error", "Please paste a valid meeting link", "OK");
        }
    }

    private async void GotoSite() {
        if(!string.IsNullOrEmpty(Text)) {
            IsWebViewVisible = true;
            if(IsWebViewVisible) {
                ToolbarVisibility = !ToolbarVisibility;
                MeetingSearchVibiility = !MeetingSearchVibiility;
                appShell.FlyoutWidth = 0;
                StartBreakTimeTimer();
                await InitializeApiPolling();
                StartMeetingTimer();

            }
        }
    }

    private async Task GetMeeetingData() {

        if(data != null) {
            var meetingData = data;
            bool isOngoing = meetingData!.data[0].ongoing;

            if(isOngoing is false) {
                await appService.DisplayAlert(Title, "you are in the lobby", "OK");
            } else if(isOngoing is true) {
                await appService.DisplayAlert(Title, "you are in the meeting", "OK");
            }
        }

    }
}
