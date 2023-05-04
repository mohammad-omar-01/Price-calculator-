namespace PriceCalculator
{
    public class ReportCalculator
    {
        public Tax tax { get; set; }
        public Discount discount { get; set; }
        public UPCDiscount upcDiscount { get; set; }
        internal Price OrginialPrice { get; set; }
        public List<AdditionalCost> additionalCosts { get; set;}
        internal Price TotalPriceToPrint {  get; private set; }
        internal double TaxAmount { get; set; }
        internal double DiscountAmount { get; set; }
        public void SetupReport(Product product)
        {
            TaxAmount = 0;
            DiscountAmount = 0;
            OrginialPrice = product.price;
            bool discountIsNotSet = true;
            bool upcDiscountIsNotSet = true;
            DiscountService discountService = new DiscountService();
            if (discount.IsBeforeTax)
            {
                DiscountAmount += discountService.CalculateDiscount(product, discount);
                discountIsNotSet = false;
            }
            if (upcDiscount.Discount.IsBeforeTax)
            {
                DiscountAmount += discountService.CalculateDiscount(product, upcDiscount.Discount);
                upcDiscountIsNotSet = false;
            }
            product.price = new (OrginialPrice.RegularPrice - DiscountAmount);

            setTaxAmount(product);

            if (discountIsNotSet) DiscountAmount += discountService.CalculateDiscount(product, discount);
            if (upcDiscountIsNotSet) DiscountAmount += discountService.CalculateDiscount(product, upcDiscount.Discount);
            DiscountAmount=Math.Round(DiscountAmount, 2);
            GetTotalPrice();

        }

        public void setTaxAmount(Product product)
        {
            TaxAmount = 0;
            TaxService taxService = new TaxService();

            TaxAmount = taxService.CalculateTax(product, tax);

        }
        public ReportCalculator()
        {
            tax = new Tax();
            discount = new Discount();
            upcDiscount=new UPCDiscount();
            OrginialPrice=new Price();
            additionalCosts = new List<AdditionalCost>();
            TotalPriceToPrint=new Price();
        }
        private void AdjustCost() {

              var list= additionalCosts.TakeWhile(item=>item.CostPersentage>0 ).ToList();

             list.ForEach(item => item.CostAmount = Math.Round(item.CostPersentage * OrginialPrice.RegularPrice,2));
            
        
        }
        public Price GetTotalPrice() {
            AdjustCost();
            double value = this.TaxAmount + this.OrginialPrice.RegularPrice - this.DiscountAmount;
            value += additionalCosts.Sum(v=>v.CostAmount);
            TotalPriceToPrint = new Price(value);
            return TotalPriceToPrint;
        }




    }
}
