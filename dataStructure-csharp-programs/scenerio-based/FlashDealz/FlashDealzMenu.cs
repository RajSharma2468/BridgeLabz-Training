using System;

namespace FlashDealz
{
    class FlashDealzMenu : IFlashDealz
    {
        private Product[] products;
        private int count;

        public FlashDealzMenu(int size)
        {
            products = new Product[size];
            count = 0;
        }

        public void AddProduct(string name, int discount)
        {
            if (count == products.Length)
            {
                Console.WriteLine("Product limit reached!");
                return;
            }

            products[count++] = new Product(name, discount);
            Console.WriteLine("Product added successfully");
        }

        public void SortByDiscount()
        {
            FlashDealzUtility.QuickSort(products, 0, count - 1);
            Console.WriteLine("Products sorted by discount (DESC)");
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\n🔥 Flash Deals:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(products[i].Name + " - " + products[i].Discount + "% OFF");
            }
        }

        public void ShowMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n1. Add Product");
                Console.WriteLine("2. Sort by Discount");
                Console.WriteLine("3. Display Products");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter discount: ");
                        int discount = int.Parse(Console.ReadLine());
                        AddProduct(name, discount);
                        break;

                    case 2:
                        SortByDiscount();
                        break;

                    case 3:
                        DisplayProducts();
                        break;
                }
            } while (choice != 4);
        }
    }
}
