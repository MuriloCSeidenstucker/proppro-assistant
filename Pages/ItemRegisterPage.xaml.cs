using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using PropproAssistant.Data;
using PropproAssistant.Models;
using System.Linq;

namespace PropproAssistant.Pages;

public sealed partial class ItemRegister : Page
{
    private Bidding _bidding;
    private bool _isValid;

    public ItemRegister()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        _bidding = e.Parameter as Bidding;
        if (_bidding is not null)
        {
            string bidNumberStr = _bidding.Number.ToString();
            int yearLength = 4;
            string year = bidNumberStr.Substring(bidNumberStr.Length - yearLength);
            string number = bidNumberStr.Substring(0, bidNumberStr.Length - yearLength);
            string formattedString = $"{number}/{year}";
            TxtBl_Bidding.Text = $"{_bidding.Modality} {formattedString}";
        }
        base.OnNavigatedTo(e);
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        _isValid = true;
        // Validar dados
        if (string.IsNullOrEmpty(TxtB_ItemNumber.Text) ||
            string.IsNullOrEmpty(TxtB_ItemAmount.Text) ||
            string.IsNullOrEmpty(TxtB_ItemCostValue.Text) ||
            string.IsNullOrEmpty(TxtB_ItemDescription.Text) ||
            string.IsNullOrEmpty(TxtB_ItemUnit.Text) ||
            string.IsNullOrEmpty(TxtB_ItemBrand.Text))
            _isValid = false;

        if (!int.TryParse(TxtB_ItemNumber.Text, out var itemNumber))
            _isValid = false;

        if (!int.TryParse(TxtB_ItemAmount.Text, out var itemAmount))
            _isValid = false;

        if (!double.TryParse(TxtB_ItemCostValue.Text, out var itemCostValue))
            _isValid = false;

        // Cadastrar item
        if (_isValid)
        {
            var item = new BiddingItem();
            item.Bidding = _bidding;
            item.Number = itemNumber;
            item.Amount = itemAmount;
            item.CostValue = itemCostValue;
            item.Description = TxtB_ItemDescription.Text;
            item.Unit = TxtB_ItemUnit.Text;
            item.Brand = TxtB_ItemBrand.Text;

            // Adicionar item na licitação
            if (!_bidding.Items.Contains(item))
            {
                _bidding.Items.Add(item);

                using var db = new AppDbContext();
                var bidding = db.Biddings.First(b => b.Id == _bidding.Id);
                bidding.Items.Add(item);
                db.SaveChanges();

                Info_Item.Title = "Item incluido com sucesso!";
                Info_Item.Severity = InfoBarSeverity.Success;
                Info_Item.IsOpen = true;
            }
        }
        else
        {
            Info_Item.Title = "Campos Inválidos";
            Info_Item.Severity = InfoBarSeverity.Error;
            Info_Item.IsOpen = true;
        }
    }
}
