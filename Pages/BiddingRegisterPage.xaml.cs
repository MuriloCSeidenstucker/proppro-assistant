using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PropproAssistant.Models;

namespace PropproAssistant.Pages;

public sealed partial class BiddingRegister : Page
{
    public BiddingRegister()
    {
        InitializeComponent();
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        var bidding = new Bidding();
        bidding.Number = TxtB_BiddingNumber.Text;
        bidding.BiddingObject = TxtB_BiddingObject.Text;
        bidding.City = TxtB_BiddingCity.Text;
        bidding.State = ((ComboBoxItem)Cbx_BiddingState.SelectedItem).Content.ToString();
        bidding.Modality = ((ComboBoxItem)Cbx_BiddingModality.SelectedItem).Content.ToString();
        bidding.JudgingType = ((ComboBoxItem)Cbx_BiddingJudgingType.SelectedItem).Content.ToString();
        bidding.Portal = ((ComboBoxItem)Cbx_BiddingPortal.SelectedItem).Content.ToString();
        bidding.Date = Date_BiddingDate.SelectedDate;

        TxtB_Test.Text = bidding.ToString();

        Frame.Navigate(typeof(ItemRegister), bidding);
    }
}
