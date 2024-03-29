﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RealworldIntFINAL;


public class StockTracker
{
    private readonly HttpClient _httpClient;

    public StockTracker()
    {
        _httpClient = new HttpClient();
    }

    public async Task<decimal> GetStockPrice(string symbol, string apiKey)
    {
        string jsonResponse = await FetchStockPrice(symbol, apiKey);
        StockPrice stockPrice = JsonSerializer.Deserialize<StockPrice>(jsonResponse);
        decimal price = decimal.Parse(stockPrice.Price);
        return price;
    }

    private async Task<string> FetchStockPrice(string symbol, string a)
    {
        string url = $"https://api.twelvedata.com/price?symbol={symbol}&apikey={a}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
        else
        {
            throw new Exception("Failed to retrieve stock price.");
        }
    }
}
