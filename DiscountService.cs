using Price_Calculator;

namespace PriceCalculator
{
    public  class DiscountService : IDiscount
    {
        public double  CalculateDiscount(Product product, Discount discount)
        {
            var discountAmount = product.price.RegularPrice * discount.DiscountRate;
            return Math.Round(discountAmount, 2);
        }

      
    }
}
