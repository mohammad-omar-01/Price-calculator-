namespace PriceCalculator
{
    public class Discount
    {
        private double discount;
        public bool IsBeforeTax { get; set; }
        public double DiscountRate
        {
            get { return discount; }
            set
            {
                if (value > 0) discount = value / 100;
                else discount = 0;
            }
        }
        public double DiscountValue { get; set; }

        public Discount()
        {
            this.DiscountRate = 0;
            this.IsBeforeTax = false;
        }

        public Discount(double value)
        {
            this.DiscountRate = value;
            this.IsBeforeTax = false;

        }
    }
}
