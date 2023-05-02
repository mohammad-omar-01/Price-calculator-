using Price_Calculator;

namespace PriceCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tax tax = new Tax(20);
            Discount discount = new Discount(15);
            UPCDiscount upcDiscount=null; 
            ProductRepository repository = new ProductRepository();
            Report report = new Report(tax, discount);
            bool DiscountIsSet = false;
            bool UpcDiscountIsSet=false;
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
                            tax.TaxRate = taxentered;
                            report.tax = tax;


                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter Discount Amount");
                            double discountEnterd = 0.1;
                            try
                            {
                                discountEnterd = double.Parse(Console.ReadLine());
                                discount.DiscountRate = discountEnterd;
                                report.discount = discount;
                                DiscountIsSet = true;


                            }
                            catch
                            {

                            }
                          

                            break;

                        }
                    case "3":
                        {
                            Console.WriteLine("\nplease Select the Report Type\n " +
                                "1. Tax Report\n" +
                                "2. Discount Report\n" +
                                "3. Total Report\n" +
                                "4. Exit the System");
                            string printReportChoice = Console.ReadLine();
                            switch (printReportChoice)
                            {
                                case "1":
                                    {
                                        foreach (var item in repository.products)
                                        {
                                            report.setTaxAmount(item, tax);
                                            report.SimplePrint(item);
                                            report.PrintWithTaxOnly(item, tax);
                                            report.PrintTotalPrice(item);

                                        }

                                        break;
                                    }
                                case "2":
                                    {
                                        foreach (var item in repository.products)
                                        {
                                            report.setTaxAmount(item, tax);

                                            report.SimplePrint(item);
                                            if(DiscountIsSet)

                                            report.PrintWithUniversalDiscount(item, discount);

                                            else
                                            {
                                                Console.WriteLine(" No Discount\n");
                                            }
                                            report.PrintTotalPrice(item,discount);

                                        }
                                        break;

                                    }
                                case "3":
                                    {
                                        foreach (var item in repository.products)
                                        {
                                            report.setTaxAmount(item, tax);

                                            report.SimplePrint(item);

                                            report.PrintWithTaxOnly(item, tax);
                                            if(DiscountIsSet)

                                                report.PrintWithUniversalDiscount(item, discount);
                                            else
                                            {
                                                Console.WriteLine(" No Discount\n");
                                            }
                                            if(UpcDiscountIsSet)
                                                report.PrintWithTotalDiscount(item,discount,upcDiscount);

                                            report.PrintTotalPrice(item,discount,upcDiscount);



                                        }
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Invalid option");

                                        break;
                                    }
                            }
                            break;
                        }
                    case "4": {

                            Console.WriteLine("Enter UPC Discount Amount");
                            double discountEnterd = 0.1;
                            try
                            {
                                discountEnterd = double.Parse(Console.ReadLine());
                                Discount discount1=new Discount(discountEnterd);
                                Console.WriteLine("Enter UPC Number");
                                var UpcNumber =  int.Parse(Console.ReadLine());


                                upcDiscount = new UPCDiscount(UpcNumber, discount1);

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
                "3. Report\n" +
                "4. Set UPC Discount\n"+
                "5. Exit\n");
            return Console.ReadLine();

        }
    }
}