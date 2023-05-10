namespace PriceCalculator
{
    public class UPCDiscount : Discount
    {
        public int UpcNumber { get; set; }

        public UPCDiscount()
        {

        }
        public UPCDiscount(int upc, double discountRate) :base(discountRate)
        {

            UpcNumber = upc;
        }

        public double CalculateUpcDiscount(Product product)
        {
            double result = 0;
            if (product.Upc == this.UpcNumber)
            {
                result = product.price.RegularPrice * this.DiscountRate;
            }
            return Math.Round(result, 2);
        }
    }
}
