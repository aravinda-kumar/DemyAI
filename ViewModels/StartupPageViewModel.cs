namespace DemyAI.ViewModels;

public class StartupPageViewModel : BaseViewModel {

    private readonly IAppService _appService;
    private readonly ISecureStorage _secureStorage;
    IDataService<DemyUser> dataService;

    public StartupPageViewModel(IAppService appService, ISecureStorage secure, IDataService<DemyUser> dataService) {

        _appService = appService;
        _secureStorage = secure;
        this.dataService = dataService;
        CheckAuth();
    }

    private async void CheckAuth() {

        var currentUserEmail = await _secureStorage.GetAsync(Constants.LOGGED_USER);

        if (string.IsNullOrEmpty(currentUserEmail)) {
            if (DeviceInfo.Platform == DevicePlatform.WinUI) {
                Shell.Current.Dispatcher.Dispatch(async () => {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
                });
            } else {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
            }
        } else {

            var loggedUser = await dataService.GetByEmailAsync(Constants.USERS,
                currentUserEmail);

            FlyoutHelper.CreateFlyoutHeader(loggedUser);

            FlyoutHelper.CreateFlyoutMenu(loggedUser?.CurrentRole!);

            await NvigationHelper.NavigatoToDashboardRoleAsync(loggedUser?.CurrentRole!);

        }
    }
}