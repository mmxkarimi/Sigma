namespace Sigma.App.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
           InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {

                await DisplayAlert("Success", "Settings saved successfully", "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }
    }
} 