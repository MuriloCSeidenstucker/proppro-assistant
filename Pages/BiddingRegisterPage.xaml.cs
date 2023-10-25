using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PropproAssistant.Models;

namespace PropproAssistant.Pages;

public sealed partial class BiddingRegister : Page
{
    private bool _isValid;

    public BiddingRegister()
    {
        InitializeComponent();
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        _isValid = true;

        // Validar todas as entradas
        if (string.IsNullOrEmpty(TxtB_BiddingNumber.Text) ||
            string.IsNullOrEmpty(TxtB_BiddingObject.Text) ||
            string.IsNullOrEmpty(TxtB_BiddingCity.Text) ||
            Cbx_BiddingState.SelectedItem is null ||
            Cbx_BiddingModality.SelectedItem is null ||
            Cbx_BiddingJudgingType.SelectedItem is null ||
            Cbx_BiddingPortal.SelectedItem is null ||
            Date_BiddingDate.SelectedDate is null)
            _isValid = false;

        if (!int.TryParse(TxtB_BiddingNumber.Text, out var biddingNumber))
            _isValid = false;

        // Criar a licitação
        if (_isValid)
        {
            var bidding = new Bidding();
            bidding.Number = biddingNumber;
            bidding.BiddingObject = TxtB_BiddingObject.Text;
            bidding.City = TxtB_BiddingCity.Text;
            bidding.State = ((ComboBoxItem)Cbx_BiddingState.SelectedItem).Content.ToString();
            bidding.Modality = ((ComboBoxItem)Cbx_BiddingModality.SelectedItem).Content.ToString();
            bidding.JudgingType = ((ComboBoxItem)Cbx_BiddingJudgingType.SelectedItem).Content.ToString();
            bidding.Portal = ((ComboBoxItem)Cbx_BiddingPortal.SelectedItem).Content.ToString();
            bidding.Date = Date_BiddingDate.SelectedDate;

            Frame.Navigate(typeof(ItemRegister), bidding);
        }
        else
        {
            Info_Bidding.IsOpen = true;
        }
    }
}
