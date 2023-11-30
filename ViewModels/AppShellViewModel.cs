namespace DemyAI.ViewModels;
public partial class AppShellViewModel : BaseViewModel {

    //This will hold the data of the user that is logged in
    [ObservableProperty]
    public required Student user;


}
