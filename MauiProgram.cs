global using CommunityToolkit.Maui;
global using CommunityToolkit.Maui.Alerts;
global using CommunityToolkit.Maui.Core;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using DemyAI.Helpers;
global using DemyAI.Interfaces;
global using DemyAI.Models;
global using DemyAI.Services;
global using DemyAI.ViewModels;
global using DemyAI.Views;

global using Firebase.Auth;
global using Firebase.Auth.Providers;
global using Firebase.Database;

global using Microsoft.Extensions.Logging;
global using Microsoft.Maui.Controls;

global using SkiaSharp.Views.Maui.Controls.Hosting;

global using Syncfusion.Maui.Core.Hosting;

global using System.Collections.ObjectModel;
global using System.Net.Http.Json;
global using System.Text.Json;
global using System.Text.Json.Serialization;

namespace DemyAI {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();

            var firebaseAuthConfig = new FirebaseAuthConfig() {
                ApiKey = "AIzaSyAdkLQ31yRPXRvFjNR8FMzjk0EzfEn3wIw",
                AuthDomain = "demyai.firebaseapp.com",
                Providers = new FirebaseAuthProvider[] {
                    new EmailProvider()
                }
            };

            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
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

            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<AppShellViewModel>();

            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();

            builder.Services.AddSingleton<WelcomePage>();
            builder.Services.AddSingleton<WelcomePageViewModel>();

            builder.Services.AddSingleton<CoursesPage>();
            builder.Services.AddSingleton<CoursesPageViewModel>();

            builder.Services.AddSingleton<NewLecturePage>();
            builder.Services.AddSingleton<NewLecturePageViewModel>();

            builder.Services.AddSingleton<NewTestPage>();
            builder.Services.AddSingleton<NewTestPageViewMode>();

            builder.Services.AddSingleton<ScheduleLecturePage>();
            builder.Services.AddSingleton<ScheduleLecturePageViewModel>();

            builder.Services.AddSingleton<ScheduleTestPage>();
            builder.Services.AddSingleton<ScheduleTestPageViewModel>();

            builder.Services.AddSingleton<NoInternetPage>();

            builder.Services.AddSingleton<CourseRegistrationPage>();

            builder.Services.AddSingleton<ManageCoursePage>();
            builder.Services.AddSingleton<ManageCoursePageViewModel>();

            builder.Services.AddSingleton<IAppService, AppService>();
            builder.Services.AddTransient(typeof(IDataService<>), typeof(DataService<>));
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

            builder.Services.AddSingleton(Connectivity.Current);

            builder.Services.AddSingleton(firebaseAuthClient);

            builder.Services.AddSingleton<IAuthenticationService>(serviceProvider => {
                var authService = serviceProvider.GetRequiredService<FirebaseAuthClient>();
                var appService = serviceProvider.GetRequiredService<IAppService>();
                return new AuthenticationService(authService, appService);
            });

            builder.Services.AddSingleton<IMeetingService, MeetingService>();

            return builder.Build();
        }
    }
}
