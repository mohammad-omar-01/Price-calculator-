using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    public class ProductTax
    {
        private TaxService taxService= new TaxService();
        public Product Product { get; set;}
        public Tax Tax { get; set; }
        public double TaxAmount { get; private set; }
        public ProductTax(Product product,Tax tax)
        {
            this.Product = product;
            this.Tax = tax;            
        }

        public double GetTax() { 
            this.TaxAmount = taxService.CalculateTax(this.Product,this.Tax);
            return (TaxAmount);

        }


    }
}
