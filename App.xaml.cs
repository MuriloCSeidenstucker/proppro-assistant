using Microsoft.UI.Xaml;
using PropproAssistant.Views;

namespace PropproAssistant;

public partial class App : Application
{
    private Window m_window;

    public App()
    {
        InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_window = new BiddingInfoView();
        //m_window = new BiddingItemsView();
        m_window.Activate();
    }
}
