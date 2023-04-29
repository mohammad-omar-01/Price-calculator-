namespace PriceCalculator
{
    public class ProductRepository
    {
        public List<Product> products = new List<Product>();
        public ProductRepository()
        {

            products.Add(new Product(1, "SampleProduct 1", 12344, 17.34));
            products.AddRange(new Product[] {
                new Product(2, "SampleProduct 2", 12345, 22.34),
                new Product(3, "SampleProduct 3", 12346, 38.34),
                new Product(4, "SampleProduct 4", 12347, 49.34)});
        }
        public Product Retrieve(int id)
        {
            var product = products.SingleOrDefault(v => v.Id == id);
            return product;
        }
        public bool Save(Product product)
        {
            var success = true;

            products.Add(product);
            return success;
        }
    }
}
