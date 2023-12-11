using User = DemyAI.Models.User;
namespace DemyAI.ViewModels;

public partial class AppShellViewModel(IAuthenticationService authenticationService, IAppService appService) : BaseViewModel {

    [ObservableProperty]
    User? user;

    [ObservableProperty]
    bool isAdmin;

    [ObservableProperty]
    bool isStudent;

    [ObservableProperty]
    bool isTeacher;

    [RelayCommand]
    async Task SignOut() {

        authenticationService.SignOut();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);

    }
}
