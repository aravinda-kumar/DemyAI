using Syncfusion.Licensing;

namespace DemyAI;
public partial class App : Application {

    public App(IConnectivity connectivity, AppShell shell, NoInternetPage noInternetPage) {

        SyncfusionLicenseProvider.RegisterLicense(Constants.LICENSE);

        InitializeComponent();

        if(connectivity.NetworkAccess is not NetworkAccess.Internet) {
            MainPage = noInternetPage;
        } else {
            MainPage = shell;
        }
    }
}
