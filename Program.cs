namespace PriceCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product book = new Product(10,"The Little Prince", 12345, 20.25);
            Tax tax = new Tax(20);
            ProductRepository repository = new ProductRepository();
            foreach (var item in repository.products) {
            item.PrintWithTax(tax);
            }

           

            



        }
    }
}