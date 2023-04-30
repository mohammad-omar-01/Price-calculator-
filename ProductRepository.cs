namespace PriceCalculator
{
    public class ProductRepository
    {
        public List<Product> products = new List<Product>();
        public ProductRepository()
        {

            products.AddRange(new Product[] {
                  new Product(10, "The Little Prince", 12345, 20.25),
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
