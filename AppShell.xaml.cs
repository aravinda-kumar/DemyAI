namespace DemyAI;
public partial class AppShell : Shell {

    public AppShell(AppShellViewModel appShellViewModel) {

        InitializeComponent();

        BindingContext = appShellViewModel;
    }


    //    private void SetupNavigationView() {
    //#if WINDOWS
    //        Loaded += delegate {
    //            NavigationView navigationView = (NavigationView)flyout.Handler!.PlatformView!;
    //            navigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.Left;

    //        };
    //#endif
}
