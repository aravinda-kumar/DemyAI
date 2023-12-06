namespace DemyAI.ViewModels;
public partial class AppShellViewModel(IAuthenticationService authenticationService, IAppService appService) : BaseViewModel {

    //This will hold the data of the user that is logged in
    [ObservableProperty]
    public required Models.User user;

    [RelayCommand]
    async Task SignOut() {

        authenticationService.SignOut();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);

    }


}
