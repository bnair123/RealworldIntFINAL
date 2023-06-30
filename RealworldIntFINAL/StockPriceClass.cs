using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RealworldIntFINAL;

public class StockPriceClass
{
    public Dictionary<string, decimal> Stocks { get; set; }

    public StockPriceClass(Dictionary<string, decimal> stocks)
    {
        Stocks = stocks;
    }

    public async Task RefreshPrices(string apiKey)
    {
        StockTracker stockTracker = new StockTracker();
        foreach (var symbol in Stocks.Keys.ToList())
        {
            decimal price = await stockTracker.GetStockPrice(symbol, apiKey);
            AddOrUpdateStock(symbol, price);
        }
    }

    public bool AddOrUpdateStock(string symbol, decimal price)
    {
        if (Stocks.ContainsKey(symbol))
        {
            Stocks[symbol] = price;
        }
        else
        {
            Stocks.Add(symbol, price);
        }
        return true;
    }

    public bool AddOrUpdateStock(string symbol, decimal price, List<string> usStockSymbols)
    {
        if (!usStockSymbols.Contains(symbol))
        {
            throw new Exception("Invalid stock symbol.");
        }

        if (Stocks.ContainsKey(symbol))
        {
            Stocks[symbol] = price;
        }
        else
        {
            Stocks.Add(symbol, price);
        }
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
        AddOrUpdateStock(symbol, price, usStockSymbols);
        return true;
    }

    public void DeleteStock(string symbol)
    {
        Stocks.Remove(symbol);
    }

    public void SaveToXml(string filePath)
    {
        using (TextWriter writer = new StreamWriter(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<string, decimal>));
            serializer.Serialize(writer, Stocks);
        }
    }

    public static StockPriceClass LoadFromXml(string filePath)
    {
        using (TextReader reader = new StreamReader(filePath))
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Dictionary<string, decimal>));
            Dictionary<string, decimal> stocks = (Dictionary<string, decimal>)deserializer.Deserialize(reader);
            return new StockPriceClass(stocks);
        }
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

