namespace DemyAI.Views;

public partial class LoginPage : ContentPage {

    private readonly IConnectivity _connectivity;
    private readonly IAppService appService;
    private bool isNavigating;

    public LoginPage(LoginPageViewModel loginPageViewModel, IConnectivity connectivity, IAppService appService) {
        InitializeComponent();

        BindingContext = loginPageViewModel;
        _connectivity = connectivity;
        this.appService = appService;
    }

    private async Task CheckInternetAndNavigate() {

        bool hasInternet = CheckInternetConnectivity();

        if (!hasInternet) {
            await appService.NavigateTo($"//{nameof(NoInternetPage)}", true);
        } else {
            await appService.NavigateTo($"//{nameof(LoginPage)}", true);
        }
    }

    private bool CheckInternetConnectivity() {
        var current = _connectivity.NetworkAccess;
        return current == NetworkAccess.Internet;
    }


    protected override async void OnAppearing() {
        base.OnAppearing();

        if (!isNavigating) {

            bool hasInsternet = CheckInternetConnectivity();

            if (!hasInsternet) {
                await appService.NavigateTo($"//{nameof(NoInternetPage)}", true);
            } else {
                isNavigating = true;
                await appService.NavigateTo($"//{nameof(LoginPage)}", true);

            }
        }
    }

}