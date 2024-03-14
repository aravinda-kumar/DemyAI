namespace DemyAI.Helpers;

public static class FlyoutHelper {

    public static void CreateFlyoutHeader(DemyUser? updatedUser) {
        Shell.Current.FlyoutHeader = new FlyoutHeader(
            new FlyoutHeaderViewModel(
                              updatedUser!.Name!,
                              updatedUser.DemyId!,
                              updatedUser.Email!,
                              updatedUser.CurrentRole!
            ));
    }

    public static void CreateFlyoutMenu(string role) {

        switch(role) {

            case nameof(Role.Student):
                CreateStudentItems();
                break;
            case nameof(Role.Teacher):
                CreateTeacherItems();
                break;
            case nameof(Role.Coordinator):
                CreateCoordintorItems();
                break;
        }
    }

    private static void CreateStudentItems() {
        var studentItems = new FlyoutItem() {
            Title = "Welcome",
            Route = nameof(StudentDashboardPage),
            FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
            Items = {

             new ShellContent {
                 Title = "Welcome",
                 ContentTemplate = new DataTemplate(typeof(WelcomePage)),
             },

             new ShellContent {
                 Title = "Join meeting",
                 ContentTemplate = new DataTemplate(typeof(JoinMeetingPage)),
             }
        }
        };

        if(!Shell.Current.Items.Contains(studentItems)) {

            Shell.Current.Items.Add(studentItems);
        }

    }

    private static void CreateTeacherItems() {
        var TeacherItems = new FlyoutItem() {
            Title = "Welcome",
            Route = nameof(TeacherDashboardPage),
            FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
            Items = {

             new ShellContent {
                 Title = "Welcome",
                 ContentTemplate = new DataTemplate(typeof(WelcomePage)),
             },

             new ShellContent {
                 Title = "My courses",
                 ContentTemplate = new DataTemplate(typeof(MyCoursesPage)),
             },

             new ShellContent {
                 Title = "New lecture",
                 ContentTemplate = new DataTemplate (typeof(NewLecturePage)),
             },

             new ShellContent {
                 Title = "New Test",
                 ContentTemplate = new DataTemplate(typeof(NewTestPage)),
             },

             new ShellContent {
                 Title = "Schedule lecture",
                 ContentTemplate = new DataTemplate (typeof(NewLecturePage)),
             },

             new ShellContent {
                 Title = "Schedule test",
                 ContentTemplate = new DataTemplate(typeof(ScheduleTestPage)),
             },
        }
        };

        if(!Shell.Current.Items.Contains(TeacherItems)) {

            Shell.Current.Items.Add(TeacherItems);

        }
    }

    private static void CreateCoordintorItems() {
        var CoordinatorItems = new FlyoutItem() {
            Title = "Welcome",
            Route = nameof(CoordinatorDashboardPage),
            FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
            Items = {

            new ShellContent {
                Title = "Welcome",
                ContentTemplate = new DataTemplate(typeof(WelcomePage)),
            },

            new ShellContent {
                Title = "Manage courses",
                ContentTemplate = new DataTemplate(typeof(ManageCoursePage)),
            },

            new ShellContent {
                Title = "Register student",
                ContentTemplate = new DataTemplate(typeof(RegisterStudentPage)),
            }
        }
        };

        if(!Shell.Current.Items.Contains(CoordinatorItems)) {

            Shell.Current.Items.Add(CoordinatorItems);
        }
    }


    public static void GeetDefaultMenuItems() {
        var defaultItems = new List<ShellContent> {

             new() { ContentTemplate = new DataTemplate(typeof(StartupPage)),
                Route = nameof(StartupPage), FlyoutItemIsVisible = false },
            new() { ContentTemplate = new DataTemplate(typeof(LoginPage)),
                Route = nameof(LoginPage), FlyoutItemIsVisible = false },
            new() { ContentTemplate = new DataTemplate(typeof(NoInternetPage)),
                Route = nameof(NoInternetPage), FlyoutItemIsVisible = false },
            new() { ContentTemplate = new DataTemplate(typeof(RoleSelectionPage)),
                Route = nameof(RoleSelectionPage), FlyoutItemIsVisible = false }
        };

        Shell.Current.Items.Clear();

        foreach(var item in defaultItems) {
            Shell.Current.Items.Add(item);
        }

    }
}
