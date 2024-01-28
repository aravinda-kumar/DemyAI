namespace DemyAI;

public partial class AppShell : Shell {
    public AppShell(AppShellViewModel appShellViewModel, IAppService appService) {
        InitializeComponent();

        BindingContext = appShellViewModel;
        RegisterPages();
    }


    private void RegisterPages() {

        Routing.RegisterRoute(nameof(CoursesPage), typeof(CoursesPage));
        Routing.RegisterRoute(nameof(JoinMeetingPage), typeof(JoinMeetingPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(ManageCoursePage), typeof(ManageCoursePage));
        Routing.RegisterRoute(nameof(NewLecturePage), typeof(NewLecturePage));
        Routing.RegisterRoute(nameof(NewTestPage), typeof(NewTestPage));
        Routing.RegisterRoute(nameof(NoInternetPage), typeof(NoInternetPage));
        Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
        Routing.RegisterRoute(nameof(RegisterStudentPage), typeof(RegisterStudentPage));
        Routing.RegisterRoute(nameof(ScheduleLecturePage), typeof(ScheduleLecturePage));
        Routing.RegisterRoute(nameof(ScheduleTestPage), typeof(ScheduleTestPage));
        Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));

    }
}
