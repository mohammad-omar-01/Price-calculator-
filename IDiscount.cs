namespace PriceCalculator
{
    public interface IDiscount
    {

        public double CalculateDiscount(Product product, Discount discount);

    }
}