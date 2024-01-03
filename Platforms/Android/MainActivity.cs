using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace DemyAI {
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]

    [IntentFilter([Intent.ActionView],
                        DataScheme = "https",
                        DataHost = "demy-ia.daily.co",
                        DataPathPrefix = "//Programming",
                        AutoVerify = true,
                        Categories = [Intent.ActionView, Intent.CategoryDefault, Intent.CategoryBrowsable])]
    public class MainActivity : MauiAppCompatActivity {

        protected override void OnCreate(Bundle? savedInstanceState) {
            base.OnCreate(savedInstanceState);

            //test
            OnNewIntent(Intent!);
        }

        protected override void OnNewIntent(Intent? intent) {
            base.OnNewIntent(intent);

            var data = intent!.DataString;

            if(Intent.ActionView == intent.Action && !string.IsNullOrEmpty(data)) {

            }
        }
    }
}
