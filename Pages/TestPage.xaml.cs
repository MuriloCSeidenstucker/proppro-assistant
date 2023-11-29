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
    public List<Tuple<string, int>> Options { get; } = new();
    
    public TestPage()
    {
        InitializeComponent();
        InitializeBiddingOptions();
    }

    private void BiddingOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateItems(e);
    }

    private void InitializeBiddingOptions()
    {
        using var db = new AppDbContext();
        
        foreach (var bid in db.Biddings)
        {
            Options.Add(new Tuple<string, int>(bid.ToString(), bid.Id));
        }
        Cbx_BiddingOptions.ItemsSource = Options;
    }

    private void UpdateItems(SelectionChangedEventArgs e)
    {
        if (e.AddedItems is null || e.AddedItems.Count == 0)
        {
            throw new ArgumentNullException($"{nameof(e.AddedItems)} não pode ser nulo ou vazio");
        }

        Tuple<string, int> selectedTuple = e.AddedItems[0] as Tuple<string, int>;

        if (selectedTuple is null)
        {
            throw new NullReferenceException($"{nameof(selectedTuple)} não pode ser nulo");
        }

        var id = selectedTuple.Item2;
        DataGrid.ItemsSource = GetItemsFromDatabase(id);
    }

    private ObservableCollection<BiddingItem> GetItemsFromDatabase(int id)
    {
        using var db = new AppDbContext();
        var bidding = db.Biddings.Include(b => b.Items).FirstOrDefault(x => x.Id == id);

        if (bidding != null)
        {
            return new ObservableCollection<BiddingItem>(bidding.Items);
        }

        throw new NullReferenceException($"{nameof(bidding)} não pode ser nulo");
    }

    private void Delete_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        int? selectedBiddingId = (int)Cbx_BiddingOptions.SelectedValue;

        using var db = new AppDbContext();
        var bidding = db.Biddings.Include(b => b.Items).FirstOrDefault(x => x.Id == selectedBiddingId);
        db.Remove(bidding);
        db.SaveChanges();
    }
}
