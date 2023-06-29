using System;
using System.Collections.Generic;
using System.Xml;
namespace RealworldIntFINAL;

public class UserVerification
{
    public string Username { get; set; }
    public string Password { get; set; }

    public UserVerification(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public Dictionary<string, int> LoadStocks()
    {
        var stocks = new Dictionary<string, int>();
        var doc = new XmlDocument();
        doc.Load($"{Username}_stocks.xml");

        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
        {
            stocks[node.Attributes["name"].Value] = int.Parse(node.Attributes["quantity"].Value);
        }

        return stocks;
    }

    public void SaveStocks(Dictionary<string, int> stocks)
    {
        var doc = new XmlDocument();
        var root = doc.CreateElement("stocks");

        foreach (var stock in stocks)
        {
            var stockNode = doc.CreateElement("stock");
            stockNode.SetAttribute("name", stock.Key);
            stockNode.SetAttribute("quantity", stock.Value.ToString());
            root.AppendChild(stockNode);
        }

        doc.AppendChild(root);
        doc.Save($"{Username}_stocks.xml");
    }
}

/*
 * For controller:
 * private UserManager userManager;

        public Controller()
        {
            userManager = new UserManager();
        }

        public Dictionary<string, int> LoginAndLoadStocks(string username, string password)
        {
            var user = userManager.Authenticate(username, password);
            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }

            return user.LoadStocks();
        }

        public void RegisterAndSaveStocks(string username, string password, Dictionary<string, int> stocks)
        {
            var user = userManager.Register(username, password);
            user.SaveStocks(stocks);
        }

 */
