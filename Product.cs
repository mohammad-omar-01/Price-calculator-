using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator
{
    public class Product
    {
        public String name { get; set; }
        public int upc { get; set; }

        public double price { get; set; }

        public double flat_rate_task { get; private set; }

        public void SetTaskPercentage(double task_percentage)
        {
            flat_rate_task = (task_percentage / 100);
        }

        public Product()
        {
            name = "";
            upc = 0;
            price = 0.0;
            flat_rate_task = 0.2;
        }
        public Product(String name, int upc, double price, double flat_rate_task)
        {
            this.name = name;
            this.upc = upc;
            this.price = price;
            SetTaskPercentage(flat_rate_task);

        }
        private double PriceAfterAddingTax() { 
            double result = 0.0;
            double added_price_after_tax = price * flat_rate_task;
            result=price+added_price_after_tax;
            return Math.Round(result, 2);
        
        }

        public void ProductPriceReport()
        {
            string formatted_price = Math.Round(price, 2).ToString("$0.00");
            string price_with_tax = PriceAfterAddingTax().ToString("$0.00");
            Console.WriteLine($"Product price reoprted as {formatted_price} before tax and " +
                $"{price_with_tax} after {flat_rate_task * 100}% tax");

        }




    }
}
