namespace DemyAI;
public partial class AppShell : Shell {

    public AppShell(AppShellViewModel appShellViewModel) {

        InitializeComponent();
        BindingContext = appShellViewModel;

        // Add default Shell items
        FlyoutHelper.GeetDefaultMenuItems();
    }

    //protected override void OnNavigating(ShellNavigatingEventArgs args) {

    //    if(DeviceInfo.Current.Idiom == DeviceIdiom.Desktop) {

    //        Preferences.Default.Get(Constants.FLYOUT_STATUS, false);
    //    }
    //    base.OnNavigating(args);
    //}
}
