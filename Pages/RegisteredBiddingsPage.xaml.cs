using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Controls;
using PropproAssistant.Data;
using System.Linq;

namespace PropproAssistant.Pages;

public sealed partial class RegisteredBiddings : Page
{
    public RegisteredBiddings()
    {
        InitializeComponent();

        using var db = new AppDbContext();
        int id = 2;
        var bidding = db.Biddings.Include(b => b.Items).FirstOrDefault(x => x.Id == id);

        if (bidding != null)
        {
            TxtBl_Bidding.Text = bidding.ToString();

            if (bidding.Items.Count > 0)
            {
                var item = bidding.Items[bidding.Items.Count - 1];
                TxtBl_ItemNumber.Text = item.Number.ToString();
                TxtBl_ItemDescription.Text = item.Description;
                TxtBl_ItemCostValue.Text = item.CostValue.ToString();
            }
        }
    }
}
