using Price_Calculator;

namespace PriceCalculator
{
    public  class Report
    {
        public Tax tax { get; set; }
        public Discount discount { get; set; }

        public UPCDiscount upcDiscount { get; set;}
        private Price OrginialPrice { get; set; }
        public Report() {
            this.tax = new Tax(0);
            this.discount = new Discount(0);
            this.upcDiscount = new UPCDiscount(0,discount);
            OrginialPrice = new Price(0);

        }
        public Report(Tax tax, Discount discount, UPCDiscount discountDiscount)
        {
            this.tax = tax;
            this.discount = discount;
            this.upcDiscount = discountDiscount;
            OrginialPrice = new Price(0);
        }
        private  double TaxAmount { get;  set; }
        private double DiscountAmount { get;  set;}
       


        public void SetupReport(Product product) {
            TaxAmount = 0;
            DiscountAmount = 0;
            OrginialPrice = product.price;
            bool discountIsNotSet = true;
            bool upcDiscountIsNotSet = true;
            DiscountService discountService = new DiscountService();
            if (discount.IsBeforeTax) {
                DiscountAmount += discountService.CalculateDiscount(product, discount);
                discountIsNotSet = false;
            }
            if (upcDiscount.Discount.IsBeforeTax) {
                DiscountAmount += discountService.CalculateDiscount(product, upcDiscount.Discount);
                upcDiscountIsNotSet = false;
            }
            product.price = new (OrginialPrice.RegularPrice - DiscountAmount);
            
            setTaxAmount(product);
            if(discountIsNotSet) DiscountAmount += discountService.CalculateDiscount(product, discount);
            if(upcDiscountIsNotSet) DiscountAmount += discountService.CalculateDiscount(product, upcDiscount.Discount);

        }

        public void setTaxAmount(Product product)
        {
            TaxAmount = 0;
            TaxService taxService = new TaxService();
                
                TaxAmount = taxService.CalculateTax(product, tax);

        }
        public  void SimplePrint( Product product)
        {
            SetupReport(product);
            Console.WriteLine($"Title \"{product.Name}\", UPC = {product.Upc}, price= {OrginialPrice.FormattedPrice} ");

        }
             
        public void PrintWithTotalDiscount(Product product)
        {
            SetupReport(product);
            Console.WriteLine($"Total Discount Amount is {DiscountAmount}");

        }

        public void PrintTotalPrice(Product product,Discount discount,UPCDiscount uPCDiscount)
        {
            double totalprice = TaxAmount + OrginialPrice.RegularPrice-DiscountAmount;
            Price totalPrice = new Price(totalprice);
            Console.WriteLine($"Total Price With All Discounts is {totalPrice.FormattedPrice}");
            Console.WriteLine($"Total Discoint is {DiscountAmount}\n");
        }

    }
}
