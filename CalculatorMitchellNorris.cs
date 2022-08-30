using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        public static double DoMathStuff(double num1, double num2, String opp)
        {
            double result = double.NaN;
            if (opp == "a")
            {
                result = (num1 + num2);
            }
            else if (opp =="s")
            {
                result = (num1 - num2);
            }
            else if (opp == "m")
            {
                result = (num1 * num2);
            }
            else if (opp == "d")
            {if (num2 != 0)
                {
                    return (num1 / num2);
                }
            }
            return result;
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            //Writes text at app start up
            Console.WriteLine("Hello! Welcome to the C# Console Calculator!\r");
            Console.WriteLine("Created By Mitchell Norris");
            Console.WriteLine("-------------------------------------------------\n");
            while (!endApp)
            {
                //starting variables that are empty
                string input1 = "";
                string input2 = "";
                double result = 0;
                Console.WriteLine("Please input your first number:");
                input1 = Console.ReadLine();
                double num1 = 0;
                while (!double.TryParse(input1, out num1))
                {
                    Console.WriteLine("Not a valid input. Try Again:");
                    input1 = Console.ReadLine();
                }
                Console.WriteLine("Please input your second number:");
                input2 = Console.ReadLine();
                double num2 = 0;
                while (!double.TryParse(input2, out num2))
                {
                    Console.WriteLine("Not a valid input. Try Again:");
                    input2 = Console.ReadLine();
                }
                string opp = "";
                Console.WriteLine("For addition, enter the character a");
                Console.WriteLine("For subtraction, enter the character s");
                Console.WriteLine("For multiplication, enter the character m");
                Console.WriteLine("For division, enter the character d");
                opp = Console.ReadLine();
                try
                {
                    result = Calculator.DoMathStuff(num1, num2, opp);
                    Console.WriteLine(result);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This opperation will cause an error. Try again.\n");
                    }
                }catch (Exception e)
                {
                    Console.WriteLine("An an exception has occured! Details:\n" + e.Message);
                }
                Console.WriteLine("-------------------------------------------------\n");
                Console.WriteLine("Please type q and enter to quit, or type any other key to continue");
                if (Console.ReadLine() == "n")
                {
                    endApp = true;
                }
               }
            return;
            }
        }
    }

