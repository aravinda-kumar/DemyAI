namespace DemyAI.ViewModels;

public partial class JoinMeetingPageViewModel(AppShell appShell, IAppService appService) : BaseViewModel {

    double currentFlyoutWith;

    [ObservableProperty]
    bool controlsVisibility = true;

    [ObservableProperty]
    bool isWebViewVisible;

    [ObservableProperty]
    string? text;

    [RelayCommand]
    void Search() {
        VerifyAddress(appService);
    }

    [RelayCommand]
    void EntryCompleted() {
        VerifyAddress(appService);
    }

    private void VerifyAddress(IAppService appService) {
        if(Text!.Contains("demy-ia")) {
            GoToite();
        } else {
            appService.DisplayAlert("Error", "Please paste a valid meeting link", "OK");
        }
    }

    private void GoToite() {
        if(!string.IsNullOrEmpty(Text)) {
            IsWebViewVisible = true;
            currentFlyoutWith = appShell.FlyoutWidth;
            ControlsVisibility = false;
            appShell.FlyoutWidth = 0;
        }
    }
}
