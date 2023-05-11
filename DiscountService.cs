namespace PriceCalculator
{
    public class DiscountService : IDiscount
    {

        public double CalculateDiscount(Product product, Discount discount)
        {
            var discountAmount = product.price.RegularPrice * discount.DiscountRate;
            discount.DiscountValue = Math.Round(discountAmount, 4);
            return discount.DiscountValue;
        }


    }
}
