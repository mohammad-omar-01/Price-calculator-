using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Price_Calculator
{
    public static class ProductUtilities
    {
        private static Product product = new Product();
        public static void CreateInstance(Product p)
        {

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

            Console.WriteLine($"Tax = {Math.Round((product.flat_rate_tax *product.price),2)}, discount = {Math.Round(product.discount_amount.Sum(v=>v.Value) * product.price,2)}" +
                $" Total price is = {FormateValue(product.total_price)} \n Discount amount is = {discount}% ");

        }

        public static void SetDiscountType(this Product product)
        {


            foreach (KeyValuePair<string, string> discount in product.discount_Type)
            {
                Console.WriteLine($"Choose Tax state for {discount.Key} \n 1. After tax \n 2. Before tax");
                string enterd_value = Console.ReadLine();

                if (enterd_value.Equals("1"))
                {
                    product.discount_Type[discount.Key] = "after_tax";
                }
                else if (enterd_value.Equals("2"))
                {
                    product.discount_Type[discount.Key] = "before_tax";
                    product.price -=  (product.price *product.discount_amount[discount.Key]);


                }
                else
                {

                    Console.WriteLine("Your Choice is Wrong , Tax has been set as default \"after tax\" ");

                }

            }

        }
        public static void AjdustPrice(this Product product)
        {
            double total_discount = 0;
            foreach (KeyValuePair<string, string> discount in product.discount_Type)
            {
                if (discount.Value == "before_tax")
                {
                     total_discount += product.price * product.discount_amount[discount.Key];
                }

            }
            product.price -= total_discount;
        }
        private static double TaxAmmount()
        {
            double added_price_after_tax = (product.price * product.flat_rate_tax);
            added_price_after_tax = Math.Round(added_price_after_tax, 2);
            return added_price_after_tax;

        }
        private static string FormateValue(double value)
        {
            return value.ToString("$0.00");
        }

        private static string FormattedTax()
        {
            double added_price_after_tax = TaxAmmount();

            return added_price_after_tax.ToString("$0.00");

        }
        private static double discountAmmount()
        {
            double result = 0;
            foreach (KeyValuePair<string, string> discount in product.discount_Type)
            {
                if (discount.Value == "after_tax")
                {
                    result += (product.price * product.discount_amount[discount.Key]);
                }

            }
            return Math.Round(result, 2);

        }

        private static string FormattedAppliedDiscount()
        {
            var total_sum = product.discount_amount.Sum(v => v.Value);
            if (total_sum == 0) { return (""); }
            //total_sum=product.price- product.price * total_sum;
            return Math.Round(total_sum*100, 2).ToString("0.00");


        }
        public static double CalculateTotalPrice(this Product p)
        {
            return product.price - discountAmmount() + TaxAmmount();

        }
        public static void ApplyUCPDisctount(this Product p, int upc, double discount)
        {
            if (p.upc != upc)
            {
                return;
            }
            p.discount_amount["upc_discount"]= discount/100;
            p.SetTotalPrice();
        }
    }

}
