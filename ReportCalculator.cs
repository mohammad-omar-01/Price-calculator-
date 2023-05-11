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
        internal Cap cap { get; set; }

        DiscountService discountService = null;

        public void SetupReport(Product product)
        {
            discountType = DiscountType.AdditiveDiscount;
            TaxAmount = 0;
            DiscountAmount = 0;
            OrginialPrice = product.price;
            discountService = new DiscountService();


            if (discount.IsBeforeTax)
            {
                DiscountAmount += discountService.CalculateDiscount(product, discount);
              
            }
            if (upcDiscount.IsBeforeTax)
            {
                if (discountType.Equals(DiscountType.MultiplicativeDiscount))
                {
                    product.price = new(OrginialPrice.RegularPrice - DiscountAmount);
                }
                DiscountAmount += discountService.CalculateDiscount(product, upcDiscount);
            }
            product.price = new (OrginialPrice.RegularPrice - DiscountAmount);

            setTaxAmount(product);

            if (!discount.IsBeforeTax) DiscountAmount += discountService.CalculateDiscount(product, discount);
            if (!upcDiscount.IsBeforeTax) {
                if (discountType.Equals(DiscountType.MultiplicativeDiscount))
                {
                    product.price = new(OrginialPrice.RegularPrice - DiscountAmount);
                }
            }
            DiscountAmount += discountService.CalculateDiscount(product, upcDiscount);
            AdjustCap();
            if(DiscountAmount>cap.CapAmount)
            {
                DiscountAmount= cap.CapAmount;
            }

            DiscountAmount=Math.Round(DiscountAmount, 4);
            GetTotalPrice();
            product.price = new(OrginialPrice.RegularPrice);

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
            cap = new Cap();
        }
        private void AdjustCost() {

              var list= additionalCosts.TakeWhile(item=>item.CostPersentage>0 ).ToList();

             list.ForEach(item => item.CostAmount = Math.Round(item.CostPersentage * OrginialPrice.RegularPrice,4));
            
        
        }
        private void AdjustCap() { 
        if(cap.CapPersentage>0)
            {
                cap.CapAmount = Math.Round(cap.CapPersentage * OrginialPrice.RegularPrice, 4);
            }
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
