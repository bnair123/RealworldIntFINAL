using System;
using System.Text.Json.Serialization;
namespace RealworldIntFINAL;
public class StockSymbol
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}
