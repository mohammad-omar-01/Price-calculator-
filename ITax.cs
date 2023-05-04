using Price_Calculator;

namespace PriceCalculator
{
    internal interface ITax
    {
        public double CalculateTax(Product product, Tax tax);
        public double CalculateDiscountAfterTax(Product product, Discount discount, Tax tax);



    }
}
