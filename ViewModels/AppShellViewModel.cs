
namespace DemyAI.ViewModels;

public partial class AppShellViewModel(IAppService appService) : BaseViewModel {

    [RelayCommand]
    async Task SignOut() {

        SecureStorage.Default.RemoveAll();

        FlyoutHelper.GeetDefaultMenuItems();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);

    }
}

