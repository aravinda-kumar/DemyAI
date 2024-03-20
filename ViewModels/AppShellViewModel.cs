
namespace DemyAI.ViewModels;

public partial class AppShellViewModel(IAppService appService, ISecureStorage secureStorage) : BaseViewModel {

    [RelayCommand]
    public void Appearing() {

        FlyoutHelper.GeetDefaultMenuItems();
    }

    [RelayCommand]
    async Task SignOut() {

        secureStorage.RemoveAll();

        FlyoutHelper.GeetDefaultMenuItems();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);

    }
}

