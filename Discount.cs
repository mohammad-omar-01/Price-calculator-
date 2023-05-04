namespace Price_Calculator
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
        public Discount() { }

        public Discount(double value)
        {
            this.DiscountRate = value;
            this.IsBeforeTax = false;

        }
    }
}
