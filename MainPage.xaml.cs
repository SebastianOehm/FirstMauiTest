using Maui.Biometric;

namespace FirstMauiTest;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAuthenticateClicked(object sender, EventArgs e)
    {
        var result = await BiometricAuthentication.Current.AuthenticateAsync(
            new AuthenticationRequest(
                title: "Authenticate",
                reason: "Please authenticate to proceed"));
        if (result.IsSuccessful)
        {
            await Shell.Current.GoToAsync("erfolg");// User authenticated
        }
        else
        {
            StatusLabel.Text = "Authentifizierung fehlgeschlagen.";
        }
    }
}