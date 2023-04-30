using Price_Calculator;

namespace PriceCalculator
{
    public  class Report
    {
        public Tax tax { get; set; }
        public Discount discount { get; set; }
        public Report(Tax tax, Discount discount)
        {
            this.tax = tax;
            this.discount = discount;
        }
        public  double TaxAmount { get; private set; }
        public  void setTaxAmount ( Product product, Tax tax)
        {
            TaxService taxService = new TaxService();

            TaxAmount = taxService.CalculateTax(product, tax);


        }


        public  void PrintWithTaxOnly( Product product, Tax tax)
        {

            double totalPrice = product.price.RegularPrice + TaxAmount;
            var formattedTotalPrice = StringFormatter.FormatRegularValue(totalPrice);

            setTaxAmount(product, tax);

            Console.WriteLine($"{TaxAmount} Total price is = {formattedTotalPrice}");


        }
        public  void SimplePrint( Product product)
        {
            Console.WriteLine($"Title \"{product.Name}\", UPC = {product.Upc}, price= {product.price.FormattedPrice} ");

        }
        public  void PrintWithDiscount( Product product,Discount discount)
        {
            DiscountService discountService = new DiscountService();
            var DiscountAmount = discountService.CalculateDiscount(product, discount);
            
            double totalprice = TaxAmount + product.price.RegularPrice - DiscountAmount;
            Price totalPrice=new Price(totalprice);

            Console.WriteLine($"{DiscountAmount} Total price is = {totalPrice.FormattedPrice}");

        }


    }
}
