namespace PriceCalculator
{
    public class ReportCalculator
    {
        public Tax tax { get; set; }
        public Discount discount { get; set; }
        public UPCDiscount upcDiscount { get; set; }
        internal Price OrginialPrice { get; set; }
        public DiscountType discountType { get; set; }
        public List<AdditionalCost> additionalCosts { get; set;}
        internal Price TotalPriceToPrint {  get; private set; }
        internal double TaxAmount { get; set; }
        internal double DiscountAmount { get; set; }
        public void SetupReport(Product product)
        {
            discountType = DiscountType.MultiplicativDiscount;
            TaxAmount = 0;
            DiscountAmount = 0;
            OrginialPrice = product.price;
            DiscountService discountService = new DiscountService();
            
            if (discount.IsBeforeTax)
            {
                DiscountAmount += discountService.CalculateDiscount(product, discount);
              
            }
            if (upcDiscount.Discount.IsBeforeTax)
            {
                if (discountType.Equals(DiscountType.MultiplicativDiscount))
                {
                    product.price = new(OrginialPrice.RegularPrice - DiscountAmount);
                }
                DiscountAmount += discountService.CalculateDiscount(product, upcDiscount.Discount);
            }
            product.price = new (OrginialPrice.RegularPrice - DiscountAmount);

            setTaxAmount(product);

            if (!discount.IsBeforeTax) DiscountAmount += discountService.CalculateDiscount(product, discount);
            if (!upcDiscount.Discount.IsBeforeTax) {
                if (discountType.Equals(DiscountType.MultiplicativDiscount))
                {
                    product.price = new(OrginialPrice.RegularPrice - DiscountAmount);
                }
            }
            DiscountAmount += discountService.CalculateDiscount(product, upcDiscount.Discount);

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
            discountType= new DiscountType();
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
