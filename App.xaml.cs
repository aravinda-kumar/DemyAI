namespace DemyAI {
    public partial class App : Application {
        public App(LoginPage shell) {
            InitializeComponent();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.LICENSE);

            MainPage = shell;
        }
    }
}
