using Microsoft.UI.Xaml.Controls;

namespace PropproAssistant.Pages;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void Register_OnClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Frame.Navigate(typeof(BiddingRegister));
    }

    private void Show_OnClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Frame.Navigate(typeof(RegisteredBiddingsPage));
    }
}
