using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Price_Calculator
{
    public  static  class ProductUtilities
    {
        private static Product product = new Product();
        public static void CreateInstance(Product p) {

            product = p;
        }


        public static void ProductPriceReport(this Product p)
        {

            string formatted_price = Math.Round(product.price, 2).ToString("$0.00");
            string tax = FormattedTax();
            string formatted_discount = FormattedAppliedDiscount();
            PrintReport(formatted_price, tax, formatted_discount);

        }
        private static void PrintReport(string price, string tax, string discount)
        {
            Console.WriteLine($"Title \"{product.name}\", UPC = {product.upc}, price= {price} ");

            Console.WriteLine($"Tax = {product.flat_rate_tax * 100}%, discount = {product.discount*100}% " +
                $"Total price is = {FormateValue( product .total_price)} \n {discount} ");

        }
        private static double TaxAmmount() {
            double added_price_after_tax = (product.price * product.flat_rate_tax);
            added_price_after_tax = Math.Round(added_price_after_tax, 2);
            return added_price_after_tax;

        }
        private static string FormateValue(double value) {
            return value.ToString("$0.00");
        }

        private static string FormattedTax()
        {
            double added_price_after_tax = TaxAmmount();
            
            return added_price_after_tax.ToString("$0.00");

        }
        private static double discountAmmount()
        {
            double discount_ammount = (product.price * product.discount);
            discount_ammount = Math.Round(discount_ammount, 2);
            return discount_ammount;

        }

        private static string FormattedAppliedDiscount()
        {
            if (product.discount == 0) { return (""); }
            double added_price_after_discount =discountAmmount();
            added_price_after_discount = Math.Round(added_price_after_discount, 2);
            return added_price_after_discount.ToString("0.00");

        }
        
        public static double CalculateTotalPrice(this Product p) { 
        return product.price -discountAmmount()+TaxAmmount();
        
        }
    }
}
