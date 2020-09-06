using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringCodes
{
    class Program
    {
        private static double rate { get; set; }
        private static double amt { get; set; }
        private static double origCalc { get; set; }
        private static double calc { get; set; }

        private static double @base = 2;
        private static int TX_RATE = 5;
        public static double MN_RATE = 5;
        public static double OH_RATE = 4;
        private static int points=1;


        //private static string state = "TEXAS";
        //private static string state = "OHIO";
        private static string state = "MAINE";
        
        static void Main(string[] args)
        {
            origCalc = 0;
            calc = origCalc;
            foo();
            Console.WriteLine($"rate {rate}");
            Console.WriteLine($"amt {amt}");
            Console.WriteLine($"calc {calc}");
            Console.WriteLine($"points {points}");
            Console.WriteLine($"-----------------------------------");
            foo2();
            Console.WriteLine($"rate {rate}");
            Console.WriteLine($"amt {amt}");
            Console.WriteLine($"calc {calc}");
            Console.WriteLine($"points {points}");
            Console.ReadLine();


        }

        public static void foo()
        {
            if (state == "TEXAS")
            {
                rate = TX_RATE;
                amt = @base * TX_RATE;
                calc = 2 * basis(amt) + extra(amt) * 1.05;
            }
            else if((state=="OHIO") || (state == "MAINE"))
            {
                if (state == "OHIO") rate = OH_RATE;
                else
                {
                    rate = MN_RATE;
                    amt = @base * rate;
                    calc = 2 * basis(amt) + extra(amt) * 1.05;

                    if (state == "OHIO") points = 2;
                }
            }
            else
            {
                rate = 1;
                amt = @base;
                calc = 2 * basis(amt) + extra(amt) * 1.05;
            }

        }

        public static void foo2()
        {
            calc = 2 * basis(amt) + extra(amt) * 1.05;

            if (state == "TEXAS")
            {
                rate = TX_RATE;
                amt = @base * TX_RATE;
            }
            else if (state == "OHIO")
            {
                rate = OH_RATE;
                points = 2;
                calc = origCalc;
            }
            else if (state == "MAINE")
            {
                rate = MN_RATE;
                amt = @base * rate;
            }
            else
            {
                rate = 1;
                amt = @base;
            }

        }

        public static void foo_differentRateForAllStates()
        {
            calc = 2 * basis(amt) + extra(amt) * 1.05;

            //Add all the states name and their rates in web.comfig and read them whatever state value is
            //This will allow us to add more states and their values in web config as needed
            rate = Convert.ToDouble(ConfigurationManager.AppSettings[state]);

            if (state == "TEXAS")
            {
                amt = @base * TX_RATE;
            }
            else if (state == "OHIO")
            {
                points = 2;
                calc = origCalc;
            }
            else if (state == "MAINE")
            {
                amt = @base * rate;
            }
            else
            {
                rate = 1;
                amt = @base;
            }

        }
        
        private static double extra(double amt)
        {
            return amt;
        }

        private static double basis(double amt)
        {
            return amt;
        }
    }
}
