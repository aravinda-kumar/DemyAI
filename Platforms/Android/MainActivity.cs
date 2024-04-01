using Android.App;
using Android.Content;
using Android.Content.PM;

namespace DemyAI;
[Activity(
    //Theme = "@style/Maui.SplashTheme",
    Theme = "@style/Maui.MainTheme.NoActionBar",
    MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]

[IntentFilter([Intent.ActionView],
                    DataScheme = "https",
                    DataHost = "demy-ia.daily.co",
                    DataPathPattern = "/.*",
                    AutoVerify = true,
                    Categories = [Intent.CategoryDefault, Intent.CategoryBrowsable])]
public class MainActivity : MauiAppCompatActivity {
    protected override void OnNewIntent(Intent? intent) {
        base.OnNewIntent(intent);

        var res = intent!.Data;

        Console.WriteLine(res);
    }
}
