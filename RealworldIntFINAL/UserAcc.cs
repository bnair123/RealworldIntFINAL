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
    private StockPriceClass stockDictionary;

    public UserClass(string username, string password)
    {
        Username = username;
        Password = password;
        StockFilePath = $"{username}_stocks.xml";
        stockDictionary = LoadStocks(username);
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
        StockPriceClass stockDictionary = new StockPriceClass(stocks);
        stockDictionary.SaveToXml(StockFilePath);
    }

    public StockPriceClass LoadStocks(string username)
    {
        string StockFilePath = $"./{username}_stocks.xml";
        if (!File.Exists(StockFilePath))
        {
            return new StockPriceClass(new Dictionary<string, decimal>());
        }
        return StockPriceClass.LoadFromXml(StockFilePath);
    }

    public void Register(string username, string password)
    {
        Username = username;
        Password = password;
        StockFilePath = $"{username}_stocks.xml";
        stockDictionary = new StockPriceClass(new Dictionary<string, decimal>());
        stockDictionary.SaveToXml(StockFilePath);
    }
}




