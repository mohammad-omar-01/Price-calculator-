using Price_Calculator;

namespace PriceCalculator
{
    public class TaxService : ITax

    {
        public double CalculateDiscountAfterTax(Product product, Discount discount, Tax tax)
        {
            var priceAfterDiscount =product.price.RegularPrice- product.price.RegularPrice * discount.DiscountRate;
           
            var TotalDiscountAmount = priceAfterDiscount * tax.TaxRate;
            return Math.Round(TotalDiscountAmount, 2); 
        }

        public double CalculateTax(Product product, Tax tax)
        {
            var taxAmoount = product.price.RegularPrice * tax.TaxRate;
            return Math.Round(taxAmoount, 2);
        }


    }
}
