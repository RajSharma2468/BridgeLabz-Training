namespace FlashDealz
{
    interface IFlashDealz
    {
        void AddProduct(string name, int discount);
        void SortByDiscount();
        void DisplayProducts();
    }
}
