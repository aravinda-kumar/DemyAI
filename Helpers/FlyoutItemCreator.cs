namespace DemyAI.Helpers;

public static class FlyoutItemCreator {

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



        Shell.Current.Items.Add(studentItems);


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

        Shell.Current.Items.Add(TeacherItems);

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

        Shell.Current.Items.Add(CoordinatorItems);

    }
}