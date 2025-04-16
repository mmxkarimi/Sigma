using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Graphics;

namespace Sigma.App
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Set status bar color (notification bar)
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#006e29")); // Your Primary color
            
            // Set navigation bar color
            Window.SetNavigationBarColor(Android.Graphics.Color.White); // Your Primary color
            
            // Make status bar icons light (white)
            Window.DecorView.SystemUiFlags = SystemUiFlags.LightStatusBar;
            
            // Make navigation bar icons dark (since we have white background)
            Window.DecorView.SystemUiFlags |= SystemUiFlags.LightNavigationBar;
        }
    }
}
