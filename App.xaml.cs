using User = DemyAI.Models.User;

namespace DemyAI;
public partial class App : Application {

    private readonly IAppService _appService;
    private readonly IAuthenticationService _authenticationService;
    private readonly IDataService<User> dataService;
    private readonly AppShellViewModel _shellViewModel;

    public App(AppShell shell, IAppService appService, IAuthenticationService authenticationService,
        IDataService<User> dataService, AppShellViewModel shellViewModel) {
        InitializeComponent();

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.LICENSE);
        _appService = appService;
        _authenticationService = authenticationService;
        _shellViewModel = shellViewModel;
        MainPage = shell;
        GetUserUID(shellViewModel, dataService, appService);

    }


    private async void GetUserUID(AppShellViewModel shell, IDataService<User> dataService, IAppService appService) {

        var CurrentUserUid = await SecureStorage.GetAsync("CurrentUser");

        if(string.IsNullOrEmpty(CurrentUserUid)) {
            await _appService.NavigateTo($"//{nameof(LoginPage)}", true);
        } else {
            await RoleVisibility.ManageFlyoutItemsVisibility(shell, dataService, CurrentUserUid, appService);
        }
    }
}
