namespace SimpleCrudAPI.Entity
{
    // Encapsulated Product entity
    public class Product
    {
        private int _productId;
        private string _name;
        private decimal _price;
        private int _quantity;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}