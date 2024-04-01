global using CommunityToolkit.Maui;
global using CommunityToolkit.Maui.Alerts;
global using CommunityToolkit.Maui.Core;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using DemyAI.Controls;
global using DemyAI.Helpers;
global using DemyAI.Interfaces;
global using DemyAI.Models;
global using DemyAI.Services;
global using DemyAI.ViewModels;
global using DemyAI.Views;
global using DemyAI.Views.Coordinator;
global using DemyAI.Views.PopUps;
global using DemyAI.Views.Student;
global using DemyAI.Views.Teacher;

global using Firebase.Auth;
global using Firebase.Auth.Providers;
global using Firebase.Database;
global using Firebase.Database.Query;

global using Microsoft.Extensions.Logging;
global using Microsoft.Maui.Controls;

global using Mopups.Hosting;
global using Mopups.Pages;
global using Mopups.Services;

global using Plugin.Maui.Audio;

global using SkiaSharp.Views.Maui.Controls.Hosting;

global using Syncfusion.Maui.Core.Hosting;
global using Syncfusion.Maui.Picker;

global using System.Collections;
global using System.Collections.ObjectModel;
global using System.Diagnostics;
global using System.Net.Http.Json;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;

using Microsoft.Maui.LifecycleEvents;

namespace DemyAI {

    public static class MauiProgram {

        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();

            var firebaseAuthConfig = new FirebaseAuthConfig() {
                ApiKey = "AIzaSyAdkLQ31yRPXRvFjNR8FMzjk0EzfEn3wIw",
                AuthDomain = "demyai.firebaseapp.com",
                Providers = [
                    new EmailProvider()
                ]
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
                            .OnLaunched((window, args) => {

                                var activatedEventArgs = Microsoft.Windows.AppLifecycle.AppInstance.GetCurrent().GetActivatedEventArgs();

                                Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs? appActivationArguments =
                                activatedEventArgs.Data as Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs;

                                var MeettingURL = appActivationArguments?.Uri;

                                if (MeettingURL != null) {
                                    HandleUri(MeettingURL);
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

            builder.Services.AddSingleton<AppShell, AppShellViewModel>();
            builder.Services.AddTransient<RegisterStudentPage, RegisterStudentPageViewModel>();
            builder.Services.AddSingleton<NoInternetPage>();
            builder.Services.AddTransient<LoginPage, LoginPageViewModel>();
            builder.Services.AddTransient<NewLecturePage, NewLecturePageViewModel>();
            builder.Services.AddTransient<NewTestPage, NewTestPageViewMode>();
            builder.Services.AddSingleton<ScheduleLecturePage, ScheduleLecturePageViewModel>();
            builder.Services.AddTransient<ScheduleTestPage, ScheduleTestPageViewModel>();
            builder.Services.AddTransient<MyCoursesPage, MyCoursesPageViewModel>();
            builder.Services.AddTransient<JoinMeetingPage, JoinMeetingPageViewModel>();
            builder.Services.AddTransient<ManageCoursePage, ManageCoursePageViewModel>();
            builder.Services.AddSingleton<StartupPage, StartupPageViewModel>();
            builder.Services.AddTransient<RoleSelectionPage, RoleSelectionPageViewModel>();
            builder.Services.AddTransient<RoomPage, RoomPageViewModel>();
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
