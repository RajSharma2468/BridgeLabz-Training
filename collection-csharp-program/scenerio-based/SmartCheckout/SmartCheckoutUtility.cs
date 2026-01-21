using System.Collections.Generic;

class SmartCheckoutUtility
{
    public Dictionary<string, int> PriceMap = new Dictionary<string, int>();
    public Dictionary<string, int> StockMap = new Dictionary<string, int>();

    public SmartCheckoutUtility()
    {
        PriceMap["Milk"] = 50;
        PriceMap["Bread"] = 40;
        PriceMap["Rice"] = 60;

        StockMap["Milk"] = 10;
        StockMap["Bread"] = 8;
        StockMap["Rice"] = 15;
    }
}
