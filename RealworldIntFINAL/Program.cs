using System;
using System.Threading.Tasks;

namespace RealworldIntFINAL;
public class Program
{
    public static async Task Main()
    {
        string symbol = "AAPL"; //This is to show implementation, should actually be in controller
        string apiKey = "2a36d9947f2b46e6b21760d7206c606a";

        StockTracker stockTracker = new StockTracker();
        decimal price = await stockTracker.GetStockPrice(symbol, apiKey);

        Console.WriteLine($"The current price of {symbol} is: {price}");
    }
}