using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using PropproAssistant.Models;

namespace PropproAssistant.Pages;

public sealed partial class ItemRegister : Page
{
    private Bidding _bidding;

    public ItemRegister()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        _bidding = e.Parameter as Bidding;
        if (_bidding is not null)
        {
            TxtBl_Bidding.Text = $"{_bidding.Modality} {_bidding.Number}";
        }
        base.OnNavigatedTo(e);
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        var item = new BiddingItem();
        item.Bidding = _bidding;
        item.Number = int.Parse(TxtB_ItemNumber.Text);
        item.Amount = int.Parse(TxtB_ItemAmount.Text);
        item.CostValue = double.Parse(TxtB_ItemCostValue.Text);
        item.Description = TxtB_ItemDescription.Text;
        item.Unit = TxtB_ItemUnit.Text;
        item.Brand = TxtB_ItemBrand.Text;

        TxtB_Test.Text = item.ToString();
    }
}
