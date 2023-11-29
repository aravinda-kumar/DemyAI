namespace DemyAI.ViewModels;
public partial class BaseViewModel : ObservableObject {

    [ObservableProperty]
    string? title;

    [ObservableProperty]
    bool isBusy;

}
