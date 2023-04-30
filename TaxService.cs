namespace PriceCalculator
{
    public class TaxService : ITax

    {
        public double CalculateTax(Product product, Tax tax)
        {
            var taxAmoount = product.price.RegularPrice * tax.TaxRate;
            return Math.Round(taxAmoount, 2);
        }

    }
}
