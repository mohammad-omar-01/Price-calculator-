namespace PriceCalculator
{
    public class ReportPrinter
    {
        public ReportCalculator ReportCalculator { get; set; }
        bool ReportIsNotSet { get; set; }
        public AvailableCurrencies currency { get; set; }
        public ReportPrinter()
        {
            ReportCalculator = new ReportCalculator();
            ReportIsNotSet = true;
            currency =  AvailableCurrencies.Dollar;
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
            Console.WriteLine($"Title \"{product.Name}\", UPC = {product.Upc}, price= {TotalOriginalPrice} {currency}");

        }
        public void PrintWithTotalDiscounts(Product product)
        {
            if (ReportIsNotSet)
            {
                ReportCalculator.SetupReport(product);
                ReportIsNotSet = false;
            }
            var DiscountAmount = ReportCalculator.DiscountAmount;
            if (DiscountAmount <= 0)
            {
                Console.WriteLine("No Discounts ");
            }
            else
            {
                Console.WriteLine($"UPC Discount is {ReportCalculator.upcDiscount.DiscountValue} {currency}");
                Console.WriteLine($"Universal Discount is {ReportCalculator.discount.DiscountValue} {currency}");
                Console.WriteLine($"Total Discount Amount is {DiscountAmount} {currency}");
            }

        }
        public void PrintTotalAdditionalCosts() { 
        if(ReportCalculator.additionalCosts.Count==0)
            {
                Console.WriteLine("No Additional Costs");
            }
        else
            {
                ReportCalculator.additionalCosts.ForEach(item => Console.WriteLine($"{item.Description},{item.CostAmount}"));
            }
        
        }
        public void PrintTax() {
            Console.WriteLine($"Tax is {ReportCalculator.TaxAmount} {currency}");
        }
        public void PrintTotalPrice()
        {
            Console.WriteLine($"Total Price With All Discounts is {ReportCalculator.TotalPriceToPrint.FormattedPrice} {currency}");
            ReportIsNotSet = true;
        }

    }
}
