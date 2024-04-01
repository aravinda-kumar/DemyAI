
namespace DemyAI.ViewModels;

public partial class AppShellViewModel(IAppService appService, ISecureStorage secureStorage) : BaseViewModel {


    [RelayCommand]
    async Task SignOut() {

        secureStorage.RemoveAll();

        FlyoutHelper.GetDefaultMenuItems();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);
    }
}

