using System;
using System.Threading.Tasks;

namespace RealworldIntFINAL;
public class Program
{
    public static async Task Main()
    {
        string symbol = "AAPL"; 

        StockTracker stockTracker = new StockTracker();
        decimal price = await stockTracker.GetStockPrice(symbol);

        Console.WriteLine($"The current price of {symbol} is: {price}");
    }
}