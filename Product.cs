using System;
using System.Collections;
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

        public double total_price { get; private set; }

        public double flat_rate_tax { get; private set; }
        public double discount { get; set; }

        public Dictionary<string, string> discount_Type = new Dictionary<string, string>() { { "universal_discount","before_tax"}, { "upc_discount", "before_tax" } };



        public Product()
        {
            name = "";
            upc = 0;
            price = 0.0;
            flat_rate_tax = 0.2;
            discount = 0;
            ProductUtilities.CreateInstance(this);
            this.SetDiscountType();
            SetTotalPrice();
        }
        public Product(String name, int upc, double price, double flat_rate_tax, double discount)
        {
            this.name = name;
            this.upc = upc;
            this.price = price;
            SetTaxPercentage(flat_rate_tax);
            this.discount = discount / 100;
            ProductUtilities.CreateInstance(this);
            this.SetDiscountType();
            SetTotalPrice();
        }
        public void SetTaxPercentage(double tax_percentage)
        {
            flat_rate_tax = (tax_percentage / 100);
        }
        public void SetTotalPrice()
        {
            this.total_price = this.CalculateTotalPrice();

        }
        

            



        }



    }




