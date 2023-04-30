using Price_Calculator;

namespace PriceCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tax tax = new Tax(20);
            Discount discount = new Discount(15);
            ProductRepository repository = new ProductRepository();
            Report report=new Report(tax,discount);
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
                                
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Discount Amount,Tax has been set to 10%");

                                discountEnterd = 0.1;
                            }
                            discount.DiscountRate = discountEnterd;
                            report.discount = discount;

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
                                            report.PrintWithTaxOnly(item,tax);

                                        }

                                        break;
                                    }
                                case "2":
                                    {
                                        foreach (var item in repository.products)
                                        {
                                            report.setTaxAmount(item, tax);

                                            report.SimplePrint(item);

                                            report.PrintWithDiscount(item,discount);
                                        }
                                        break;

                                    }
                                case "3":
                                    {
                                        foreach (var item in repository.products)
                                        {
                                            report.setTaxAmount(item, tax);

                                            report.SimplePrint(item);

                                            report.PrintWithTaxOnly(item,tax);

                                            report.PrintWithDiscount(item,discount);
                                            

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
                    case "4":
                        {
                            return ;
                        }


                }
            }


        }
        public static string menu()
        {

            Console.WriteLine("1. Set Tax\n" +
                "2. Set Discount\n" +
                "3. Report\n" +
                "4. Exit");
            return Console.ReadLine();

        }
    }
}