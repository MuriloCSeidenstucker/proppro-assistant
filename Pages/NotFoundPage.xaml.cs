using Microsoft.UI.Xaml.Controls;

namespace PropproAssistant.Pages;

public sealed partial class NotFound : Page
{
    public NotFound()
    {
        InitializeComponent();
    }

    private void Back_OnClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Frame.Navigate(typeof(MainPage));
    }
}
