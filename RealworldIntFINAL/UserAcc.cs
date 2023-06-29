using System;
using System.Collections.Generic;
using System.IO;
using non;
using RealworldIntFINAL;

public class UserClass
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string StockFilePath { get; set; }
    private StockDictionary stockDictionary;

    public UserClass(string username, string password)
    {
        Username = username;
        Password = password;
        StockFilePath = $"{username}_stocks.xml";
        stockDictionary = LoadStocks();
    }

    public bool Login(string username, string enteredPassword)
    {
        UserManager userManager = new UserManager();
        UserClass authenticatedUser = userManager.Authenticate(username, enteredPassword);
        if (authenticatedUser != null)
        {
            Username = authenticatedUser.Username;
            Password = authenticatedUser.Password;
            StockFilePath = authenticatedUser.StockFilePath;
            stockDictionary = authenticatedUser.stockDictionary;
            return true;
        }
        return false;
    }

    public void Logout(string currentUsername)
    {
        if (Username == currentUsername)
        {
            UserManager userManager = new UserManager();
            userManager.SaveStocks(this);
        }
    }

    public void SaveStocks(string username, Dictionary<string, decimal> stocks)
    {
        string StockFilePath = $"./{username}_stocks.xml";
        StockDictionary stockDictionary = new StockDictionary(stocks);
        stockDictionary.SaveToXml(StockFilePath);
    }

    public Dictionary<string, decimal> LoadStocks(string username)
    {
        string StockFilePath = $"./{username}_stocks.xml";
        if (!File.Exists(StockFilePath))
        {
            return new Dictionary<string, Stock>();
        }
        return StockDictionary.LoadFromXml(StockFilePath).Stocks;
    }
}



