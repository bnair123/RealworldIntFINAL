using non;
using System;
using System.Collections.Generic;

namespace RealworldIntFINAL;

public class Controller
{
    //StockPriceClass
    //StockTracker
    //UserAcc
    //userVerification
    //

    private UserClass userManager;
    StockSymbolProvider symbolProvider = new StockSymbolProvider();
    string apikey = "2a36d9947f2b46e6b21760d7206c606a"

    List<string> usStockSymbols = await symbolProvider.GetUSStockSymbols(apiKey);


    public Controller()
    {
        userManager = new UserManager();

    }

    //Users
    public bool AuthenticateUser(string username, string password)
    {
        return userManager.Login(username, password);
    }

    public bool RegisterUser(string username, string password)
    {
        return userManager.Register(username, password);
    }

    public Dictionary<string, decimal> LoadUserStocks(string username)
    {
        return userManager.LoadStocks(username);
    }

    public void SaveUserStocks(string username, Dictionary<string, double> stocks)
    {
        userManager.SaveStocks(username, stocks);
    }

    // Stocks
    public List<Stock> GetAllStocks()
    {
    }

    public Stock GetStock(string stockName)
    {
    }

    public void AddStock(Stock stock)
    {
    }

    public void RemoveStock(string stockName)
    {
    }

}
