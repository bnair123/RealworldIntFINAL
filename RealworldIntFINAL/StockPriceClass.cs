using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RealworldIntFINAL;

public class StockDictionary
{
    public string Username { get; set; }
    public string Password { get; set; }
    public StockDictionary Stocks { get; set; }

    public StockDictionary(StockDictionary stocks)
    {
        Stocks = stocks;
    }

    public async Task RefreshPrices(string apiKey)
    {
        StockTracker stockTracker = new StockTracker();
        foreach (var symbol in Stocks.Stocks.Keys.ToList())
        {
            decimal price = await stockTracker.GetStockPrice(symbol, apiKey);
            Stocks.AddOrUpdateStock(symbol, price);
        }
    }

    public bool AddOrUpdateStock(string symbol, decimal price, List<string> usStockSymbols)
    {
        if (!usStockSymbols.Contains(symbol))
        {
            throw new Exception("Invalid stock symbol.");
        }

        Stocks.AddOrUpdateStock(symbol, price);
        return true;
    }

    public bool AddOrUpdateStock(string symbol, List<string> usStockSymbols, string apiKey)
    {
        if (!usStockSymbols.Contains(symbol))
        {
            throw new Exception("Invalid stock symbol.");
        }

        StockTracker stockTracker = new StockTracker();
        decimal price = stockTracker.GetStockPrice(symbol, apiKey).Result;
        Stocks.AddOrUpdateStock(symbol, price);
        return true;
    }

    public void DeleteStock(string symbol)
    {
        Stocks.RemoveStock(symbol);
    }
}


/*
 * To initialize:
 *
 * string filePath = "stocks.xml";
 *
 * StockDictionary myStocks;
 * savedStocks = StockDictionary.LoadFromXml(filePath);
 * myStocks.AddOrUpdateStock("AAPL", 150.73m);
 * myStocks.RemoveStock("GOOGL");
 * myStocks.SaveToXml(filePath);
 * StockDictionary updatedStocks = StockDictionary.LoadFromXml(filePath);
 *
 *
 */

