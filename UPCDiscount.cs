namespace PriceCalculator
{
    public class UPCDiscount
    {
        public int UpcNumber { get; set; }

        public Discount Discount { get; set; }
        public UPCDiscount()
        {
            Discount = new Discount();
        }
        public UPCDiscount(int upc, Discount discountRate)
        {
            UpcNumber = upc;
            Discount = discountRate;
        }

        public double CalculateUpcDiscount(Product product)
        {
            double result = 0;
            if (product.Upc == this.UpcNumber)
            {
                result = product.price.RegularPrice * Discount.DiscountRate;
            }
            return Math.Round(result, 2);
        }
    }
}
