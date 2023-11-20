using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Controls;
using PropproAssistant.Data;
using PropproAssistant.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PropproAssistant.Pages;

public sealed partial class TestPage : Page
{
    public ObservableCollection<BiddingItem> Items { get; private set; }
    public List<Tuple<string, int>> Options { get; } = new();
    
    public TestPage()
    {
        InitializeComponent();

        using var db = new AppDbContext();

        foreach (var bid in db.Biddings)
        {
            string bidNumberStr = bid.Number.ToString();
            int yearLength = 4;
            string year = bidNumberStr.Substring(bidNumberStr.Length - yearLength);
            string number = bidNumberStr.Substring(0, bidNumberStr.Length - yearLength);
            string formattedString = $"{number}/{year}";
            string temp = $"{bid.Modality} {formattedString} - {bid.City}";
            Options.Add(new Tuple<string, int>(temp, bid.Id));
        }
        Cbx_BiddingOptions.ItemsSource = Options;
    }

    private void BiddingOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Tuple<string, int> test = e.AddedItems[0] as Tuple<string, int>;
        if (test != null)
        {
            using var db = new AppDbContext();
            var id = test.Item2;
            var bidding = db.Biddings.Include(b => b.Items).FirstOrDefault(x => x.Id == id);

            if (bidding != null)
            {
                Items = new ObservableCollection<BiddingItem>(bidding.Items);
            }
            DataGrid.ItemsSource = Items;
        }
    }
}
