using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    internal static  class Report
    {
        public static void PrintWithTax (this Product product,Tax tax) {
            SimplePrint(product);
            var productTax=new ProductTax(product, tax);
            double amountOfTax = productTax.GetTax();
            double totalPrice = product.Price.RegularPrice + amountOfTax;
            var formattedTotalPrice=StringFormatter.FormatRegularValue(totalPrice);



            Console.WriteLine($"{amountOfTax} Total Price is = {formattedTotalPrice}");


        }
        public static void SimplePrint(this Product product) {
            Console.WriteLine($"Title \"{product.Name}\", UPC = {product.Upc}, Price= {product.Price.FormattedPrice} ");

        }


    }
}
