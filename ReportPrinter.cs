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
                Console.WriteLine($"UPC Discount is ${ReportCalculator.upcDiscount.Discount.DiscountValue}");
                Console.WriteLine($"Universal Discount is ${ReportCalculator.discount.DiscountValue}");
                Console.WriteLine($"Total Discount Amount is {DiscountAmount}");
            }

        }
        public void PrintTotalAdditionalCosts() { 
        if(ReportCalculator.additionalCost.Count==0)
            {
                Console.WriteLine("No Additional Costs");
            }
        else
            {
                ReportCalculator.additionalCost.ForEach(item => Console.WriteLine($"{item.Description},{item.CostAmount}"));
            }
        
        }
        public void PrintTax() {
            Console.WriteLine($"Tax is ${ReportCalculator.TaxAmount}");
        }
        public void PrintTotalPrice()
        {
            Console.WriteLine($"Total Price With All Discounts is {ReportCalculator.TotalPriceToPrint.FormattedPrice}");
            ReportIsNotSet = true;
        }

    }
}
