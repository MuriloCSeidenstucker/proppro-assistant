using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using PropproAssistant.Pages;
using System;

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
        m_window = new MainWindow();

        Frame rootFrame = new Frame();
        rootFrame.NavigationFailed += OnNavigationFailed;
        rootFrame.Navigate(typeof(MainPage), args.Arguments);

        m_window.Content = rootFrame;
        m_window.Activate();
    }

    private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }
}
