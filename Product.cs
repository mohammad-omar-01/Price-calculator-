namespace PriceCalculator
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public int Upc { get; set; }

        public Price Price { get; set; }

        public Product(int id, string name = "", int upc = 0, double price = 0.0)
        {
            this.Id = id;
            this.Name = name;
            this.Upc = upc;
            this.Price = new(price);
        }
    }
}




