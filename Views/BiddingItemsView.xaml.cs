using Microsoft.UI.Xaml;
using PropproAssistant.Models;

namespace PropproAssistant.Views;

public sealed partial class BiddingItemsView : Window
{
    private BiddingItem _biddingItem;

    public BiddingItemsView()
    {
        InitializeComponent();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        _biddingItem = new BiddingItem();
        _biddingItem.Number = int.Parse(TxtB_ItemNumber.Text);
        _biddingItem.Amount = int.Parse(TxtB_ItemAmount.Text);
        _biddingItem.CostValue = double.Parse(TxtB_ItemCostValue.Text);
        _biddingItem.Description = TxtB_ItemDescription.Text;
        _biddingItem.Unit = TxtB_ItemUnit.Text;
        _biddingItem.Brand = TxtB_ItemBrand.Text;

        TxtB_Test.Text = _biddingItem.ToString();
    }
}
