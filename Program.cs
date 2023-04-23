namespace Price_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product book = new Product("The Little Prince", 12345, 20.25, 20,0);
            book.ProductPriceReport();


        }
    }
}