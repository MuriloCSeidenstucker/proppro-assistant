using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PropproAssistant.Models;
using System;

namespace PropproAssistant.Views;

public sealed partial class BiddingInfoView : Window
{
    private BiddingInfo _biddingInfo;

    public BiddingInfoView()
    {
        InitializeComponent();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        _biddingInfo = new BiddingInfo();
        _biddingInfo.Number = TxtB_BiddingNumber.Text;
        _biddingInfo.BiddingObject = TxtB_BiddingObject.Text;
        _biddingInfo.City = TxtB_BiddingCity.Text;
        _biddingInfo.State = ((ComboBoxItem)Cbx_BiddingState.SelectedItem).Content.ToString();
        _biddingInfo.Date = Date_BiddingDate.SelectedDate;
        _biddingInfo.Modality = ((ComboBoxItem)Cbx_BiddingModality.SelectedItem).Content.ToString();
        _biddingInfo.JudgingType = ((ComboBoxItem)Cbx_BiddingJudgingType.SelectedItem).Content.ToString();
        _biddingInfo.Portal = ((ComboBoxItem)Cbx_BiddingPortal.SelectedItem).Content.ToString();

        TxtB_Test.Text = _biddingInfo.ToString();
    }
}
