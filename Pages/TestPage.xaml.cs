using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Controls;
using PropproAssistant.Data;
using PropproAssistant.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PropproAssistant.Pages;

public sealed partial class TestPage : Page
{
    public ObservableCollection<BiddingItem> Items { get; }
    public double PageHeight;

    public TestPage()
    {
        InitializeComponent();

        using var db = new AppDbContext();
        int id = 3;
        var bidding = db.Biddings.Include(b => b.Items).FirstOrDefault(x => x.Id == id);

        if (bidding != null)
        {
            Items = new ObservableCollection<BiddingItem>(bidding.Items);
        }
        DataGrid.ItemsSource = Items;
    }
}
