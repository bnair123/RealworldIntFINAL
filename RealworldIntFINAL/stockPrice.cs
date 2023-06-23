using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace RealworldIntFINAL;

public class StockPrice
{
    [JsonPropertyName("price")]
    public string Price { get; set; }
}
