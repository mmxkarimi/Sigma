namespace Sigma.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), async (handler, view) =>
            {
#if ANDROID
                var window = handler.PlatformView.Window;
                window.SetSoftInputMode(Android.Views.SoftInput.AdjustResize);
#endif
            });
            InitializeComponent();
        }
    }
}
