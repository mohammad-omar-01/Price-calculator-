namespace PriceCalculator
{
    internal class TaxService : ITax

    {
        public double CalculateTax(Product product, Tax tax)
        {
            var taxAmoount = product.Price.RegularPrice * tax.TaxRate;
            return Math.Round(taxAmoount, 2);
        }

    }
}
