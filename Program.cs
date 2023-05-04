using Price_Calculator;
using System.Runtime.CompilerServices;

namespace PriceCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Discount discount = new Discount(0);
            UPCDiscount upcDiscount = new UPCDiscount();

            ProductRepository repository = new ProductRepository();
            Report report = new Report();
            bool DiscountIsSet = false;
            bool UpcDiscountIsSet = false;
            while (true)
            {
                string choice = menu();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter Tax Amount");
                            double taxentered = 0.1;
                            try
                            {
                                taxentered = double.Parse(Console.ReadLine());

                            }
                            catch
                            {
                                Console.WriteLine("Invalid Tax Amount,Tax has been set to 10%");

                                taxentered = 0.1;
                            }
                            Tax tax = new Tax(taxentered);
                            report.tax = tax;


                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter Discount Amount");
                            double discountEnterd = 0.0;
                            try
                            {
                                

                                discountEnterd = double.Parse(Console.ReadLine());
                                Console.WriteLine("Set Discount Type : 1. Applied After Tax   2. Applied before Tax");
                                var discountType = Console.ReadLine();
                                if (discountType.Equals("1"))
                                {
                                    discount.IsBeforeTax = false;
                                }
                                else if (discountType.Equals("2"))
                                {
                                    discount.IsBeforeTax = true;
                                }
                                else
                                {
                                    Console.WriteLine("invalid Choice, DiscountType is has been set to be taken after Tax \n");
                                }

                                discount.DiscountRate = discountEnterd;
                                report.discount = discount;
                                DiscountIsSet = true;



                            }
                            catch
                            {

                            }


                            break;

                        }
                    case "4":
                        {
                           
                            foreach (var item in repository.products)
                            {

                                report.SimplePrint(item);
                                report.PrintTotalPrice(item, discount, upcDiscount);

                            }
                            break;

                        }
                    case "3":
                        {
                            Console.WriteLine("Enter UPC Discount Amount");
                            double discountEnterd = 0.0;
                            try
                            {
                                discountEnterd = double.Parse(Console.ReadLine());
                                Discount discount1 = new Discount(discountEnterd);
                                Console.WriteLine("Set Upc Discount Type : 1. Applied After Tax   2. Applied before Tax");
                                var discountType = Console.ReadLine();
                                if (discountType.Equals("1"))
                                {
                                    discount1.IsBeforeTax = false;
                                }
                                else if (discountType.Equals("2"))
                                {
                                    discount1.IsBeforeTax = true;
                                }
                                Console.WriteLine("Enter UPC Number");
                                var UpcNumber = int.Parse(Console.ReadLine());


                                upcDiscount.UpcNumber = UpcNumber;
                                upcDiscount.Discount = discount1;
                                report.upcDiscount=upcDiscount;
                                UpcDiscountIsSet = true;


                            }
                            catch
                            {
                                throw new Exception();


                            }

                            break;
                        }
                    case "5":
                        {
                            return;
                        }


                }
            }


        }
        public static string menu()
        {

            Console.WriteLine("1. Set Tax\n" +
                "2. Set Discount\n" +
                "3. Set UPC Discount\n" +
                "4. Report\n" +
                "5. Exit\n");
            return Console.ReadLine();

        }
    }
}