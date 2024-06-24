using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Menu();

                string Choice = EnterSelection();

                if (Choice == "5")
                {
                    break;
                }

                double WaterLastMonth = WaterInput("Enter the amount of water last month: ");
                double WaterThisMonth = WaterInput("Enter the amount of water this month: ");
                while (WaterThisMonth < WaterLastMonth)
                {
                    Console.WriteLine("The amount of water this month must be greater than the amount last month");
                    WaterLastMonth = WaterInput("Enter the amount of water last month: ");
                    WaterThisMonth = WaterInput("Enter the amount of water this month: ");

                }
                
                Console.Write("Enter your name:");
                string name = Console.ReadLine();
                double WaterConsumption = WaterThisMonth - WaterLastMonth;
                double Result = Calculate(Choice , WaterLastMonth, WaterThisMonth);

                Console.WriteLine("\n=========== Water bill =============\n");
                Console.WriteLine("Customer: " + name);
                Console.WriteLine("Amount of water used last month: " + WaterLastMonth + " (M3)");
                Console.WriteLine("Amount of water used this month: " + WaterThisMonth + " (M3)");
                Console.WriteLine("Amount of water consumed: " + WaterConsumption + " (M3)");
                Console.WriteLine("Total cost: " + Result +" (VND)");
            }

        }

        static void Menu()
        {
            Console.WriteLine("\n====== Cwater bill program ======");
            Console.WriteLine("1. Household customer\n2. Administrative agency, public services\n3. Production units\n4. Business services\n5. Exit ");
            Console.WriteLine("Enter customer type: ");
        }

        static string EnterSelection()
        {
            string Choice = Console.ReadLine();

            while (Choice != "1" && Choice != "2" && Choice != "3" && Choice != "4" && Choice != "5")
            {
                Console.WriteLine("Re-enter 1 to 5");
                Choice = Console.ReadLine();
            }
            return Choice;
        }

        static double WaterInput (string message)
        {
            Console.Write(message);
            double WaterAmout ;
            while (!double.TryParse(Console.ReadLine(), out WaterAmout) || WaterAmout < 0)
            {
                Console.WriteLine("Re enter " + message.ToLower());
            }
            return WaterAmout;
        }

        static double Calculate (string Choice, double WaterLastMonth, double WaterThisMonth)
        {

            double WaterPerPerson = 0;
            double EnvironmentalTax = 0;
            double WaterConsumption = WaterThisMonth - WaterLastMonth;

            switch (Choice)
            {

                case "1":
                    Console.WriteLine("Customers are households:");
                    Console.WriteLine("Enter number of users:");
                    int User;
                    while (!int.TryParse(Console.ReadLine(), out User) || User < 0)
                    {
                        Console.WriteLine("Re enter:");
                    }
                    double ConsumptionPerPerson = WaterConsumption / User;
                    if (ConsumptionPerPerson <= 10)
                    {
                        WaterPerPerson = 5973;
                        EnvironmentalTax = 597.3;
                    }
                    else if (ConsumptionPerPerson <= 20)
                    {
                        WaterPerPerson = 7052;
                        EnvironmentalTax = 705.2;

                    }
                    else if (ConsumptionPerPerson <= 30)
                    {
                        WaterPerPerson = 8699;
                        EnvironmentalTax = 869.9;

                    }
                    else
                    {
                        WaterPerPerson = 15929;
                        EnvironmentalTax = 1592.9;

                    }
                    break;

                case "2":
                    Console.WriteLine("Administrative agency, public services:");
                    WaterPerPerson = 9955;
                    EnvironmentalTax = 995.5;


                    break;
                case "3":
                    Console.WriteLine("Production units:");
                    WaterPerPerson = 11615;
                    EnvironmentalTax = 1161.5;

                    break;

                case "4":
                    Console.WriteLine("Business services:");
                    WaterPerPerson = 22068;
                    EnvironmentalTax = 2206.8;
                    break;
                default:
                    Console.WriteLine("Requirement does not exist");
                    break;

            }
            double TotalMoney = WaterConsumption * (WaterPerPerson + EnvironmentalTax);
            double Vat = TotalMoney * 0.1;
            return TotalMoney + Vat;
        }


    }
}
