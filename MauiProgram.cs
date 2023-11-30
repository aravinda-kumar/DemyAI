global using CommunityToolkit.Maui;
global using CommunityToolkit.Maui.Alerts;
global using CommunityToolkit.Maui.Core;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

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

global using Syncfusion.Maui.Core.Hosting;

global using System.Text.Json;

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
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IAppService, AppService>();
            builder.Services.AddTransient(typeof(IDataService<>), typeof(DataService<>));
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<AppShellViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<NewLecturePage>();
            builder.Services.AddSingleton<NewLecturePageViewModel>();
            builder.Services.AddSingleton<ScheduleLecturePage>();
            builder.Services.AddSingleton<ScheduleLecturePageViewModel>();
            builder.Services.AddSingleton<MeetingsPage>();
            builder.Services.AddSingleton<MeetingsPageViewModel>();

            var firebaseAuthClient = new FirebaseAuthClient(firebaseAuthConfig);

            builder.Services.AddSingleton(firebaseAuthClient);

            builder.Services.AddSingleton<IAuthenticationService>(serviceProvider => {
                var authService = serviceProvider.GetRequiredService<FirebaseAuthClient>();
                var appService = serviceProvider.GetRequiredService<IAppService>();
                return new AuthenticationService(authService, appService);
            });


            return builder.Build();
        }
    }
}
