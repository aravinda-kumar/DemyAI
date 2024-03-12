namespace DemyAI.ViewModels;

public partial class FlyoutHeaderViewModel(string displyName, string demyId, string email, string currentRole) : BaseViewModel {

    [ObservableProperty]
    string demyId = demyId;

    [ObservableProperty]
    string name = displyName;

    [ObservableProperty]
    string email = email;

    [ObservableProperty]
    string currentRole = currentRole;
}

