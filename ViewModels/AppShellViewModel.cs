namespace DemyAI.ViewModels;

public partial class AppShellViewModel(IAuthenticationService authenticationService, IAppService appService) : BaseViewModel {

    [RelayCommand]
    async Task SignOut() {

        authenticationService.SignOut();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);

    }

}
