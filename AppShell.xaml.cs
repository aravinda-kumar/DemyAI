namespace DemyAI;

public partial class AppShell : Shell {

    public AppShell(AppShellViewModel appShellViewModel) {

        InitializeComponent();
        // SetupNavigationView();
        BindingContext = appShellViewModel;

        Routing.RegisterRoute(nameof(MyCoursesDetailPage), typeof(MyCoursesDetailPage));
    }

    protected override void OnAppearing() {

        FlyoutHelper.GetDefaultMenuItems();

    }


    //    private void SetupNavigationView() {
    //#if WINDOWS
    //        Loaded += delegate {
    //            Microsoft.UI.Xaml.Controls.NavigationView navigationView = (Microsoft.UI.Xaml.Controls.NavigationView)flyout.Handler!.PlatformView!;
    //            navigationView.PaneDisplayMode = Microsoft.UI.Xaml.Controls.NavigationViewPaneDisplayMode.LeftMinimal;

    //        };
    //    }
    //#endif
}

