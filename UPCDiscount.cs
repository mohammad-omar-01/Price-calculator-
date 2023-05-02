using Price_Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    public class UPCDiscount
    {
        public int UpcNumber { get; set; }

        public Discount UPCdiscount { get; set; } 
        public UPCDiscount(int upc, Discount discountRate)
        {
            UpcNumber = upc;
            UPCdiscount = discountRate;
        }

        public double CalculateUpcDiscount(Product product)
        {
            double result = 0;
            if (product.Upc == this.UpcNumber) {
                result =  product.price.RegularPrice * UPCdiscount.DiscountRate;
            }
            return Math.Round(result,2);
        }
    }
}
