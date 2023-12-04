namespace DemyAI.ViewModels;
public partial class BaseViewModel : ObservableObject {

    [ObservableProperty]
    string? title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(isNotBusy))]
    bool isBusy;


    public bool isNotBusy => !IsBusy;

}
