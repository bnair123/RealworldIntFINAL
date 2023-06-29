using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RealworldIntFINAL;

public class StockDictionary
{
    public Dictionary<string, decimal> Stocks { get; set; }

    public StockDictionary()
    {
        Stocks = new Dictionary<string, decimal>();
    }

    public void AddOrUpdateStock(string symbol, decimal price)
    {
        if (Stocks.ContainsKey(symbol))
        {
            Stocks[symbol] = price;
        }
        else
        {
            Stocks.Add(symbol, price);
        }
    }

    public void RemoveStock(string symbol)
    {
        if (Stocks.ContainsKey(symbol))
        {
            Stocks.Remove(symbol);
        }
    }

    public void SaveToXml(string filePath)
    {
        using (TextWriter writer = new StreamWriter(filePath))
        {
            StockDictionarySerializer serializer = new StockDictionarySerializer();
            serializer.Serialize(writer, this);
        }
    }

    public static StockDictionary LoadFromXml(string filePath)
    {
        using (TextReader reader = new StreamReader(filePath))
        {
            return StockDictionarySerializer.Deserialize(reader);
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

