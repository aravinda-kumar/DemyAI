namespace DemyAI.ViewModels;
public partial class BaseViewModel : ObservableObject {

    [JsonIgnore]
    [ObservableProperty]
    string? title;

    [JsonIgnore]
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(isNotBusy))]
    bool isBusy;

    [JsonIgnore]
    public bool isNotBusy => !IsBusy;

    public void ShowAlert(PopupPage page) => MainThread.BeginInvokeOnMainThread(async () => {
        await MopupService.Instance.PushAsync(page);
    });
}
