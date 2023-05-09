namespace PriceCalculator
{
    public class Price
    {
        public string FormattedPrice { get; set; }
        public double RegularPrice { get; set; }
        public Price() { }
        public Price(double price)
        {
            FormattedPrice = price.FormatRegularValue();
            RegularPrice = price;

        }
    }
}