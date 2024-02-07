using System.Diagnostics;

namespace DemyAI.ViewModels;

public partial class JoinMeetingPageViewModel(AppShell appShell, IAppService appService) : BaseViewModel {

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
    string elapsedTimeString;

    private Stopwatch stopwatch = new();

    private Timer chronometerTimer;
    private Timer alertTimer;


    //[RelayCommand]
    //void ShowPeople() {


    //}

    [RelayCommand]
    async Task EntryCompleted() {
        await VerifyAddressAsync(appService);
        StartChronometer();

    }

    private void StartAlertTimer() {
        alertTimer = new Timer(state => ShowAlert(), null, TimeSpan.FromMinutes(1), Timeout.InfiniteTimeSpan);
    }

    private void ShowAlert() {
        MainThread.BeginInvokeOnMainThread(async () => {
            await appService.DisplayAlert("Warning", "No one is paying attention", "OK");
        });
    }

    private void StartChronometer() {
        stopwatch.Start();
        chronometerTimer = new Timer(state => UpdateElapsedTime(), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    private void UpdateElapsedTime() {
        TimeSpan elapsed = stopwatch.Elapsed;
        ElapsedTimeString = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";

    }

    private async Task VerifyAddressAsync(IAppService appService) {
        if(Text!.Contains("demy-ia")) {

            /* Unmerged change from project 'DemyAI (net8.0-android)'
            Before:
                        await GotoSiteAsync();
            After:
                        await GotoSite();
            */

            /* Unmerged change from project 'DemyAI (net8.0-ios)'
            Before:
                        await GotoSiteAsync();
            After:
                        await GotoSite();
            */

            /* Unmerged change from project 'DemyAI (net8.0-maccatalyst)'
            Before:
                        await GotoSiteAsync();
            After:
                        await GotoSite();
            */
            GotoSite();
            // appShell.FlyoutWidth = 0;
        } else {
            await appService.DisplayAlert("Error", "Please paste a valid meeting link", "OK");
        }
    }

    private void GotoSite() {
        if(!string.IsNullOrEmpty(Text)) {
            IsWebViewVisible = true;
            if(IsWebViewVisible) {
                RoomName = Text.Split("/")[3];
                ToolbarVisibility = !ToolbarVisibility;
                MeetingSearchVibiility = !MeetingSearchVibiility;
                appShell.FlyoutWidth = 0;
                names.Add("Eduardo Gomez");
                StartAlertTimer();
                names.Add("Eduard Castillo");

            }
        }
    }
}
