using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace DemyAI {
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]

    [IntentFilter([Intent.ActionView],
                        DataScheme = "https",
                        DataHost = "demy-ia.daily.co",
                        DataPathPattern = "/.*",
                        AutoVerify = true,
                        Categories = [Intent.ActionView, Intent.CategoryDefault, Intent.CategoryBrowsable])]
    public class MainActivity : MauiAppCompatActivity {
        protected override void OnNewIntent(Intent? intent)     {
            base.OnNewIntent(intent);

            var res = intent!.Data;
        }
    }
}
