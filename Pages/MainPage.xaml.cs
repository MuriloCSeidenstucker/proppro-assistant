using Microsoft.UI.Xaml.Controls;

namespace PropproAssistant.Pages;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void nv_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        string selectedItemTag = args.InvokedItemContainer.Tag.ToString();

        switch (selectedItemTag)
        {
            case "BiddingRegister":
                contentFrame.Navigate(typeof(BiddingRegister));
                break;
            case "ItemRegister":
                contentFrame.Navigate(typeof(ItemRegister));
                break;
            case "RegisteredBiddings":
                contentFrame.Navigate(typeof(RegisteredBiddings));
                break;
            case "NotFound":
                contentFrame.Navigate(typeof(NotFound));
                break;
            default:
                break;
        }
    }
}
