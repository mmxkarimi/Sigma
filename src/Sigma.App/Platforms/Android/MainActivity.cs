using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Graphics;
using Color = Android.Graphics.Color;

namespace Sigma.App.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.SetStatusBarColor(Color.ParseColor("#212529")); 
            Window.SetNavigationBarColor(Color.ParseColor("#f8f9fa"));
            Window.DecorView.SystemUiFlags |= SystemUiFlags.LightNavigationBar;
        }
    }
}
