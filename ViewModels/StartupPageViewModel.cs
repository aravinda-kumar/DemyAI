namespace DemyAI.ViewModels;

public class StartupPageViewModel : BaseViewModel {

    private readonly IAppService _appService;

    public StartupPageViewModel(IAppService appService) {

        _appService = appService;
        CheckAuth();
    }

    private async void CheckAuth() {

        var currentUserAsJson = await SecureStorage.GetAsync(Constants.LOGGED_USER);

        if(string.IsNullOrEmpty(currentUserAsJson)) {
            if(DeviceInfo.Platform == DevicePlatform.WinUI) {
                Shell.Current.Dispatcher.Dispatch(async () => {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
                });
            } else {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
            }
        } else {

            var loggedUser = await StorageHelper<DemyUser>.GetJsonFromStorageAsync(currentUserAsJson);

            FlyoutHelper.CreateFlyoutHeader(loggedUser);

            FlyoutHelper.CreateFlyoutMenu(loggedUser?.CurrentRole!);

            await NvigationHelper.NavigatoToDashboardRoleAsync(loggedUser?.CurrentRole!);

        }
    }
}