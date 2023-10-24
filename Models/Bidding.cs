using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropproAssistant.Models;

public class Bidding
{
    [Key]
    public int Id { get; set; }

    public string Number { get; set; }
    public string BiddingObject { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Modality { get; set; }
    public string JudgingType { get; set; }
    public string Portal { get; set; }
    public DateTimeOffset? Date { get; set; }

    public List<BiddingItem> Items { get; set; }

    public override string ToString()
    {
        return $"{Number}, {BiddingObject}, {City}, {State}, {Modality}, {JudgingType}, {Portal}, {Date}";
    }
}
