namespace PriceCalculator
{
    public class DiscountService : IDiscount
    {

        public double CalculateDiscount(Product product, Discount discount)
        {
            var discountAmount = product.price.RegularPrice * discount.DiscountRate;
            discount.DiscountValue = Math.Round(discountAmount, 2);
            return discount.DiscountValue;
        }


    }
}
