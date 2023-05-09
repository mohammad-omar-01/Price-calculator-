using PriceCalculator;

namespace Price_Calculator
{
    public interface IDiscount
    {
        public double CalculateDiscount(Product product, Discount discount);
    }
}