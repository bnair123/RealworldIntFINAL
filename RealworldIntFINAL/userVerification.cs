using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
namespace RealworldIntFINAL;

public class UserManager
{
    private XmlDocument doc;
    private string usersFile = "users.xml";

    public UserManager()
    {
        doc = new XmlDocument();
        if (!File.Exists(usersFile))
        {
            var root = doc.CreateElement("users");
            var userNode = CreateUserNode("admin", "admin");
            root.AppendChild(userNode);
            doc.AppendChild(root);
            doc.Save(usersFile);
        }
        else
        {
            doc.Load(usersFile);
        }
    }

    private XmlNode CreateUserNode(string username, string password)
    {
        var userNode = doc.CreateElement("user");
        userNode.SetAttribute("username", username);
        userNode.SetAttribute("password", password);
        return userNode;
    }

    public UserClass Authenticate(string username, string password)
    {
        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
        {
            if (node.Attributes["username"].Value == username && node.Attributes["password"].Value == password)
            {
                return new UserClass(username, password);
            }
        }

        return null;
    }

    public UserClass Register(string username, string password)
    {
        var userNode = CreateUserNode(username, password);
        doc.DocumentElement.AppendChild(userNode);
        doc.Save(usersFile);
        return new UserClass(username, password);
    }

    public void SaveStocks(UserClass user)
    {
        string stockFilePath = $"{user.Username}_stocks.xml";
        user.SaveStocks(stockFilePath);
    }
}