using non;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealworldIntFINAL;

public class Controller
{
    //StockPriceClass
    //StockTracker
    //UserAcc
    //userVerification
    //

    private UserClass userManager;
    private StockSymbolProvider symbolProvider;
    private StockPriceClass stockPriceClass;
    private string apiKey = "2a36d9947f2b46e6b21760d7206c606a";
    private List<string> usStockSymbols;

    public Controller()
    {
        userManager = new UserClass("username", "password");
        symbolProvider = new StockSymbolProvider();
        usStockSymbols = symbolProvider.GetUSStockSymbols(apiKey).Result;
    }

    //Users
    public bool AuthenticateUser(string username, string password)
    {
        bool isAuthenticated = userManager.Login(username, password);
        if (isAuthenticated)
        {
            Dictionary<string, decimal> userStocks = userManager.LoadStocks(username);
            stockPriceClass = new StockPriceClass(userStocks);
        }
        return isAuthenticated;
    }

    public void RegisterUser(string username, string password)
    {
        userManager.Register(username, password);
    }

    public Dictionary<string, decimal> LoadUserStocks(string username)
    {
        return userManager.LoadStocks(username);
    }

    public void SaveUserStocks(string username, Dictionary<string, decimal> stocks)
    {
        userManager.SaveStocks(username, stocks);
    }

    // Stocks
    public async Task RefreshPrices()
    {
        await stockPriceClass.RefreshPrices(apiKey);
    }

    public bool AddOrUpdateStock(string symbol, decimal price)
    {
        return stockPriceClass.AddOrUpdateStock(symbol, price, usStockSymbols);
    }

    public bool AddOrUpdateStock(string symbol)
    {
        return stockPriceClass.AddOrUpdateStock(symbol, usStockSymbols, apiKey);
    }

    public void DeleteStock(string symbol)
    {
        stockPriceClass.DeleteStock(symbol);
    }

}
