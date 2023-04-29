namespace PriceCalculator
{
    public class Price
    {
        public String FormattedPrice { get;private set; }
        public double RegularPrice { get; set; }
        public Price(double price) {
            this.FormattedPrice=StringFormatter.FormatRegularValue(price);
            this.RegularPrice = price;
        
        }
    }
}