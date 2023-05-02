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
            setTaxAmount(product, tax);

            Console.WriteLine($"Tax Amount is {TaxAmount}");

        }
        public  void SimplePrint( Product product)
        {
            Console.WriteLine($"Title \"{product.Name}\", UPC = {product.Upc}, price= {product.price.FormattedPrice} ");

        }
        public  void PrintWithUniversalDiscount( Product product,Discount discount)
        {
            DiscountService discountService = new DiscountService();

            var DiscountAmount = discountService.CalculateDiscount(product, discount);

            Console.WriteLine($"Uneversal discount amount is {DiscountAmount}");

        }
        

        public void PrintWithTotalDiscount(Product product, Discount discount,UPCDiscount upcDiscount)
        {
            DiscountService discountService = new DiscountService();


            var DiscountAmount = discountService.CalculateDiscount(product, discount);
            var upcDiscountAmount = upcDiscount.CalculateUpcDiscount(product);
            DiscountAmount += upcDiscountAmount;

            if (upcDiscountAmount > 0)
            {
                var formattedUpcDiscount=StringFormatter.FormatRegularValue(upcDiscountAmount);
                Console.WriteLine($"UpcNumber Discount is {formattedUpcDiscount}");
            }

            Console.WriteLine($"Total Discount Amount is {DiscountAmount}");

        }

        public void PrintTotalPrice(Product product) {
            double totalprice = TaxAmount + product.price.RegularPrice;
            Price totalPrice = new Price(totalprice);
            Console.WriteLine($"Total Price With Tax Only is {totalPrice.FormattedPrice}  \n");
        }
        public void PrintTotalPrice(Product product,Discount discount)
        {
            DiscountService discountService = new DiscountService();

            var DiscountAmount = discountService.CalculateDiscount(product, discount);

            double totalprice = TaxAmount + product.price.RegularPrice-DiscountAmount;
            Price totalPrice = new Price(totalprice);
            Console.WriteLine($"Total Price With Tax And Universal Discount Only is {totalPrice.FormattedPrice} \n");
        }
        public void PrintTotalPrice(Product product,Discount discount,UPCDiscount uPCDiscount)
        {
            DiscountService discountService = new DiscountService();

            var DiscountAmount = discountService.CalculateDiscount(product, discount);
            var UpcDiscountAmount=uPCDiscount.CalculateUpcDiscount(product);
            DiscountAmount += UpcDiscountAmount;

            double totalprice = TaxAmount + product.price.RegularPrice-DiscountAmount;
            Price totalPrice = new Price(totalprice);
            Console.WriteLine($"Total Price With All Discounts is {totalPrice.FormattedPrice} \n");
        }

    }
}
