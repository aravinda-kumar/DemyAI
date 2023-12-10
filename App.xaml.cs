namespace DemyAI;
public partial class App : Application {
    public App(AppShell shell) {
        InitializeComponent();

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.LICENSE);

        MainPage = shell;
    }
}
