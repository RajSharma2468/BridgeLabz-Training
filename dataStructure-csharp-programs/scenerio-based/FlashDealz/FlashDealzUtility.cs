using System;

internal class FlashDealzUtility : IFlashDealz
{
    private Product[] _productsList;
    private int _productIndex;

    public FlashDealzUtility()
    {
        _productsList = new Product[10];
        _productIndex = 0;
    }

    public void ListAllProducts()
    {
        Console.WriteLine("\n==== PRODUCT LIST ====\n");

        if (_productIndex == 0)
        {
            Console.WriteLine("Zero products available...\n");
            return;
        }

        Console.WriteLine("Products sorted from highest to lowest discount:\n");
        for (int i = 0; i < _productIndex; i++)
        {
            Console.WriteLine(_productsList[i]);
        }
    }

    public void AddAProduct()
    {
        Console.WriteLine("\n==== PRODUCT ADDITION WINDOW ====\n");

        if (_productIndex == _productsList.Length)
        {
            ResizeProductsList();
        }

        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter original price: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("Enter discount percent: ");
        double discount = double.Parse(Console.ReadLine());

        _productsList[_productIndex++] = new Product(name, price, discount);

        QuickSort(0, _productIndex - 1);

        Console.WriteLine("\nProduct added successfully!\n");
    }

    public void ProductWithMostDiscount()
    {
        Console.WriteLine("\n==== HIGHEST DISCOUNTED PRODUCT ====\n");

        if (_productIndex == 0)
        {
            Console.WriteLine("Zero products available...\n");
            return;
        }

        Console.WriteLine(_productsList[0]);
    }

    // ---------------- QUICK SORT ----------------

    private void QuickSort(int left, int right)
    {
        if (left >= right) return;

        int pivotIndex = Partition(left, right);
        QuickSort(left, pivotIndex - 1);
        QuickSort(pivotIndex + 1, right);
    }

    private int Partition(int left, int right)
    {
        Product pivot = _productsList[right];
        int boundary = left - 1;

        for (int i = left; i < right; i++)
        {
            if (_productsList[i].GetDiscountPercent() >= pivot.GetDiscountPercent())
            {
                boundary++;
                Swap(boundary, i);
            }
        }

        Swap(boundary + 1, right);
        return boundary + 1;
    }

    private void Swap(int i, int j)
    {
        Product temp = _productsList[i];
        _productsList[i] = _productsList[j];
        _productsList[j] = temp;
    }

    private void ResizeProductsList()
    {
        Product[] temp = new Product[_productsList.Length * 2];
        for (int i = 0; i < _productIndex; i++)
        {
            temp[i] = _productsList[i];
        }
        _productsList = temp;
    }
}
