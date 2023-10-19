using System.ComponentModel.DataAnnotations;

namespace PropproAssistant.Models;

public class BiddingItem
{
    [Key]
    public int Id { get; set; }

    public int Number { get; set; }
    public int Amount { get; set; }
    public double CostValue { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public string Brand { get; set; }

    public int BiddingKey { get; set; }
    public BiddingInfo Bidding { get; set; }

    public override string ToString()
    {
        return $"{Number}, {Description}, {Unit}, {Amount}, {Brand}, {CostValue}";
    }
}
