
namespace DemyAI.ViewModels;

public partial class AppShellViewModel(IAppService appService) : BaseViewModel {

    [ObservableProperty]
    bool status;

    partial void OnStatusChanged(bool value) {

        if(DeviceInfo.Current.Idiom == DeviceIdiom.Desktop) {

            Preferences.Default.Set(Constants.FLYOUT_STATUS, value);
        }
    }

    [RelayCommand]
    async Task SignOut() {

        SecureStorage.Default.RemoveAll();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);
    }
}
