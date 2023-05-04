namespace PriceCalculator
{
    public class ReportPrinter
    {
        public ReportCalculator ReportCalculator { get; set; }
        bool ReportIsNotSet { get; set; }
        public ReportPrinter()
        {
            ReportCalculator = new ReportCalculator();
            ReportIsNotSet = true;
        }
        public ReportPrinter(ReportCalculator reportCalculator)
        {
            this.ReportCalculator = reportCalculator;
            ReportIsNotSet = true;

        }
        public void SimplePrint(Product product)
        {
            var TotalOriginalPrice = product.price.FormattedPrice;
            if (ReportIsNotSet)
            {
                ReportCalculator.SetupReport(product);
                ReportIsNotSet = false;
            }
            Console.WriteLine($"Title \"{product.Name}\", UPC = {product.Upc}, price= {TotalOriginalPrice}");

        }
        public void PrintWithTotalDiscount(Product product)
        {
            if (ReportIsNotSet)
            {
                ReportCalculator.SetupReport(product);
                ReportIsNotSet = false;
            }

            var DiscountAmount = ReportCalculator.DiscountAmount;
            Console.WriteLine($"Total Discount Amount is {DiscountAmount}");

        }
        public void PrintTotalPrice()
        {
            Console.WriteLine($"Total Price With All Discounts is {ReportCalculator.TotalPriceToPrint.FormattedPrice}");
            Console.WriteLine($"Total Discoint is {ReportCalculator.DiscountAmount}\n");
            ReportIsNotSet = true;
        }

    }
}
