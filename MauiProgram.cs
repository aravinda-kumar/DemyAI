namespace DemyAI {

    public static class MauiProgram {

        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();

            var firebaseAuthConfig = new FirebaseAuthConfig() {
                ApiKey = "AIzaSyAdkLQ31yRPXRvFjNR8FMzjk0EzfEn3wIw",
                AuthDomain = "demyai.firebaseapp.com",
                Providers = [
                    new EmailProvider()
                ],
            };

            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureMopups()
                .ConfigureLifecycleEvents(events => {
#if WINDOWS
                    events.AddWindows(windows => windows
                            .OnWindowCreated((window) => {

                                window.ExtendsContentIntoTitleBar = false;
                                var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                                var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                                var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
                                switch (appWindow.Presenter) {
                                    case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                                        overlappedPresenter.Maximize();
                                        break;
                                }
                            }));
#endif
                })
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIconsRound-Regular.otf", "Mat");
                })
                .ConfigureEssentials(essentials => {
                    essentials.UseMapServiceToken(Constants.MAPKEY);
                });

            var firebaseAuthClient = new FirebaseAuthClient(firebaseAuthConfig);

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddSingleton<IAppService, AppService>();
            builder.Services.AddSingleton(typeof(IDataService<>), typeof(DataService<>));
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<IHttpService, HttpService>();
            builder.Services.AddSingleton(Connectivity.Current);
            builder.Services.AddSingleton(SecureStorage.Default);
            builder.Services.AddSingleton(firebaseAuthClient);

            builder.Services.AddTransient<AppShell, AppShellViewModel>();
            builder.Services.AddTransient<RegisterStudentPage, RegisterStudentPageViewModel>();
            builder.Services.AddSingleton<NoInternetPage>();
            builder.Services.AddTransient<LoginPage, LoginPageViewModel>();
            builder.Services.AddTransient<NewLecturePage, NewLecturePageViewModel>();
            builder.Services.AddTransient<NewTestPage, NewTestPageViewMode>();
            builder.Services.AddTransient<ScheduleLecturePage, ScheduleLecturePageViewModel>();
            builder.Services.AddTransient<ScheduleTestPage, ScheduleTestPageViewModel>();
            builder.Services.AddTransient<MyCoursesPage, MyCoursesPageViewModel>();
            builder.Services.AddTransient<JoinMeetingPage, JoinMeetingPageViewModel>();
            builder.Services.AddTransient<ManageCoursePage, ManageCoursePageViewModel>();
            builder.Services.AddSingleton<StartupPage, StartupPageViewModel>();
            builder.Services.AddTransient<RoleSelectionPage, RoleSelectionPageViewModel>();
            builder.Services.AddTransient<MyCoursesDetailPage, MyCoursesDetailPageViewModel>();


            builder.Services.AddSingleton<IAuthenticationService>(serviceProvider => {
                var authService = serviceProvider.GetRequiredService<FirebaseAuthClient>();
                var appService = serviceProvider.GetRequiredService<IAppService>();
                return new AuthenticationService(authService, appService);
            });

            builder.Services.AddSingleton<IMeetingService, MeetingService>();




            return builder.Build();
        }

        private static void HandleUri(Uri? MeettingURL) {
            Shell.Current.GoToAsync($"//{nameof(JoinMeetingPage)}", true, new Dictionary<string, object>() {
                                        {"MeettingURL", MeettingURL!}
                                    });
        }
    }
}
