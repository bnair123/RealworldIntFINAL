using System;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string StockFilePath { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        StockFilePath = $"{username}_stocks.xml";
    }

    public bool Login(string username, string enteredPassword)
    {
    }

    public void Logout()
    {
      
    }

    public StockDictionary LoadStocks()
    {
        if (!File.Exists(StockFilePath))
        {
            return new StockDictionary();
        }
        return StockDictionary.LoadFromXml(StockFilePath);
    }

    public void SaveStocks(StockDictionary stocks)
    {
        stocks.SaveToXml(StockFilePath);
    }
}

