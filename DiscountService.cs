using Price_Calculator;

namespace PriceCalculator
{
    internal class DiscountService : IDiscount
    {
        double IDiscount.CalculateDiscount(Product product, Discount discount)
        {
            var discountAmount = product.Price.RegularPrice * discount.DiscountRate;
            return Math.Round(discountAmount, 2);
        }
    }
}
