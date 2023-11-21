using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace PropproAssistant.Models;

public class Bidding
{
    [Key]
    public int Id { get; set; }

    [Range(5, 8, ErrorMessage = "Apenas números, digite o número da licitação e o ano")]
    public int Number { get; set; }

    public string BiddingObject { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Modality { get; set; }
    public string JudgingType { get; set; }
    public string Portal { get; set; }
    public DateTimeOffset? Date { get; set; }

    public List<BiddingItem> Items { get; set; } = new();

    public override string ToString()
    {
        string bidNumberStr = Number.ToString();
        int yearLength = 4;
        string year = bidNumberStr.Substring(bidNumberStr.Length - yearLength);
        string number = bidNumberStr.Substring(0, bidNumberStr.Length - yearLength);
        string formattedString = $"{number}/{year}";
        return $"{Modality} {formattedString} - {City}";
    }
}
