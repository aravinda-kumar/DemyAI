using User = DemyAI.Models.User;
namespace DemyAI.ViewModels;

public partial class AppShellViewModel(IAuthenticationService authenticationService, IAppService appService) : BaseViewModel {

    [ObservableProperty]
    User? user;

    [ObservableProperty]
    bool isCoordinator;

    [ObservableProperty]
    bool isStudent;

    [ObservableProperty]
    bool isTeacher;

    [ObservableProperty]
    bool isRegisterOpen;

    [RelayCommand]
    async Task SignOut() {

        authenticationService.SignOut();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);

    }
}
