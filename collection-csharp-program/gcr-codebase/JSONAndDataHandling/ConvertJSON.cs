using Newtonsoft.Json;
using System;
using System.Xml;

class Program
{
    static void Main()
    {
        string json = "{'name':'Raj','age':22}";
        XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "Root");
        doc.Save("output.xml");
    }
}
