namespace PriceCalculator
{
    internal class Program
    {
        static string Currencyprint() {
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            ProductRepository repository = new ProductRepository();
            ReportPrinter report = new ReportPrinter();
            ReportCalculator reportCalculator = new ReportCalculator();
            AvailableCurrencies currency = AvailableCurrencies.Dollar;
            while (true)
            {
                string choice = menu();
                switch (choice)
                {
                    case "0": {
                            Console.WriteLine("Choose Currency");
                            string currencyChoice= Currencyprint();
                            currency = (AvailableCurrencies) int.Parse(currencyChoice)-1;
                            report.currency = currency;

                            

                            
                            break; }
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
                            reportCalculator.tax = new Tax(taxentered);


                            break;
                        }
                    case "2":
                        {
                            Discount discount = new Discount(0);

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
                                reportCalculator.discount = discount;
                            }
                            catch
                            {

                            }


                            break;

                        }
                    case "3":
                        {
                            UPCDiscount upcDiscount = new UPCDiscount();

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
                                    upcDiscount.IsBeforeTax = false;
                                }
                                else if (discountType.Equals("2"))
                                {
                                    upcDiscount.IsBeforeTax = true;
                                }
                                Console.WriteLine("Enter UPC Number");
                                var UpcNumber = int.Parse(Console.ReadLine());


                                upcDiscount.UpcNumber = UpcNumber;
                                reportCalculator.upcDiscount = upcDiscount;
                            }
                            catch
                            {
                                throw new Exception();


                            }

                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("AdditionalCosts ");
                            bool flag = true;
                            while (flag)
                            {
                                try
                                {
                                    AdditionalCost additionalCost = new AdditionalCost();
                                    Console.WriteLine("1. Add additional Costs  2.End");
                                    string typed = Console.ReadLine();
                                    if (typed.Equals("1"))
                                    {
                                        Console.WriteLine("Enter Cost Description");
                                        additionalCost.Description = Console.ReadLine();
                                        Console.WriteLine("Enter Cost type: 1. Value 2.Percentage");
                                        string costType = Console.ReadLine();


                                        if (costType.Equals("1"))
                                        {
                                            Console.WriteLine("Enter Value Amount ");

                                            additionalCost.CostAmount = double.Parse(Console.ReadLine());

                                        }
                                        else if (costType.Equals("2"))
                                        {
                                            Console.WriteLine("Enter Percentage Amount ");

                                            additionalCost.CostPersentage = double.Parse(Console.ReadLine());
                                        }
                                        reportCalculator.additionalCosts.Add(additionalCost);
                                    }
                                    else if (typed.Equals("2"))
                                    {
                                        flag = false;
                                        break;
                                    }

                                }
                                catch
                                {
                                    throw new Exception();
                                }
                            }
                            break;

                        }
                    case "5":
                        {
                            Console.WriteLine("1.Enter Cap amount 2. Enter Cap Percentage");
                            string choiceForCap= Console.ReadLine();
                            if (choiceForCap.Equals("1"))
                            {
                                Console.WriteLine("Enter Value Amount ");
                                double capAmountEnterd = Double.Parse(Console.ReadLine());
                                Cap cap = new Cap();
                                cap.CapAmount = capAmountEnterd;
                                reportCalculator.cap = cap;
                            }
                            else {
                                Console.WriteLine("Enter Percentage Amount ");
                                double capPercentage = Double.Parse(Console.ReadLine());
                                Cap cap = new Cap();
                                cap.CapPersentage=capPercentage;
                                reportCalculator.cap = cap;

                            }




                            break;
                        }
                    case "6":
                        {
                            report.ReportCalculator = reportCalculator;

                            foreach (var item in repository.products)
                            {

                                report.SimplePrint(item);
                                report.PrintWithTotalDiscounts(item);
                                report.PrintTax();
                                report.PrintTotalAdditionalCosts();
                                report.PrintTotalPrice();

                            }
                            break;

                        }
                    case "7":
                        {
                            return;
                        }


                }
            }


        }
        public static string menu()
        {
            Console.WriteLine("" +
                "0. Set Currency\n"+
                "1. Set Tax\n" +
                "2. Set Discount\n" +
                "3. Set UPC Discount\n" +
                "4. Add Additonal Costs\n" +
                "5. Set Cap Amount\n" +
                "6. Report\n" +
                "7. Exit\n");
            return Console.ReadLine();

        }
    }
}