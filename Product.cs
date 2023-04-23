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
            ProductUtilities.CreateInstance(this);
            this.total_price=this.CalculateTotalPrice();

        }
        public Product(String name, int upc, double price, double flat_rate_tax, double discount)
        {
            this.name = name;
            this.upc = upc;
            this.price = price;
            SetTaskPercentage(flat_rate_tax);
            this.discount = discount / 100;
            ProductUtilities.CreateInstance(this);
            this.total_price=this.CalculateTotalPrice();





        }
        public void SetTaskPercentage(double task_percentage)
        {
            flat_rate_tax = (task_percentage / 100);
        }

       

    }




}
