namespace PriceCalculator
{
    public class Tax
    {
        private double tax;

        public double TaxRate
        {
            get { return tax; }
            set { if (value > 0) tax = value/100;
                else tax = 0;
            }
        }

        public Tax(double value)
        {
            this.TaxRate = value;
            
        }
    }
}