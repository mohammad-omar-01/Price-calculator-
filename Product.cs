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

        public double total_price { get; set; }

        public double flat_rate_tax { get; private set; }
        public double discount { get; set; }

        public Product()
        {
            name = "";
            upc = 0;
            price = 0.0;
            flat_rate_tax = 0.2;
            discount = 0;
        }
        public Product(String name, int upc, double price, double flat_rate_tax, double discount)
        {
            this.name = name;
            this.upc = upc;
            this.price = price;
            SetTaskPercentage(flat_rate_tax);
            this.discount = discount / 100;
            SetTotalPrice();

        }
        public void SetTaskPercentage(double task_percentage)
        {
            flat_rate_tax = (task_percentage / 100);
        }

        private double ApplyDiscount()
        {
            double added_price_after_discount = (price * this.discount);
            return Math.Round(added_price_after_discount, 2);
        }
        private double PriceAfterAddingTax()
        {
            double added_price_after_tax = price * flat_rate_tax;
            return Math.Round(added_price_after_tax, 2);

        }
        private void SetTotalPrice()
        {
            this.total_price = price + PriceAfterAddingTax() - ApplyDiscount();
        }

        

    }
}
