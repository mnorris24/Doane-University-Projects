using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class View
    {
        public String GetOpp()
        {
            Console.WriteLine("For addition, enter the character a");
            Console.WriteLine("For subtraction, enter the character s");
            Console.WriteLine("For multiplication, enter the character m");
            Console.WriteLine("For division, enter the character d");
            String Op = Console.ReadLine();
            return Op;
        }
        public void Intro()
        {
            Console.WriteLine("Hello! Welcome to the C# Console Calculator!\r");
            Console.WriteLine("Created By Mitchell Norris");
            Console.WriteLine("-------------------------------------------------\n");
        }
        public void Outro()
        {
            bool Q = false;
            Console.WriteLine("-------------------------------------------------\n");
            Console.WriteLine("Please type q and enter to quit, or type any other key to continue");
        }
        public double Input1()
        {
            Console.WriteLine("Please enter the first number:");
            String In1 = Console.ReadLine();
            double number1 = 0;
            while (!double.TryParse(In1, out number1))
            {
                Console.WriteLine("Not a valid input. Try Again:");
                In1 = Console.ReadLine();
            }
            return number1;
        }
        public double Input2()
        {
            Console.WriteLine("Please enter the second number:");
            String In2 = Console.ReadLine();
            double number2 = 0;
            while (!double.TryParse(In2, out number2))
            {
                Console.WriteLine("Not a valid input. Try Again:");
                In2 = Console.ReadLine();
            }
            return number2;
        }
        public void PrintResult(double result)
        {
            Console.WriteLine(result);
        }
        public bool EndApp()
        {
            string end = Console.ReadLine();
            if (end != "q")
            {
                return false;
            }
            return true;
        }
        public void End()
        {
            Console.WriteLine("Thank you for using the Calculator App");
        }
    }
    class Controler
    {
        private Calculator calculator;
        private View view;
        public Controler()
        {
                view = new View();
                view.Intro();
            while (view.EndApp() != true)
            {
                calculator = new Calculator(view.Input1(), view.Input2(), view.GetOpp());
                view.PrintResult(calculator.DoMathStuff());
                view.Outro();
                if (view.EndApp() == true)
                {
                    break;
                }
            }
            view.End();
                
        }
    }
    class Calculator
    {
        bool endApp;
        string opperation;
        double num1;
        double num2;
        double result;
        public Calculator()
        {
            bool endApp = false;
            string opperation = "";
            double num1 = 0;
            double num2 = 0;
            double result = double.NaN;
        }
        public Calculator(double in1, double in2, string op)
        {
            num1 = in1;
            num2 = in2;
            Opperation = op;

        }
        public bool EndApp
        {
            get { return endApp; }
            set { endApp = value; }
        }
        public double Num1
        {
            get { return num1; }
            set { num1 = value; }
        }
        public double Num2
        {
            get { return num2; }
            set { num2 = value; }
        }
        public string Opperation
        {
            get { return opperation; }
            set { opperation = value; }
        }
        public double DoMathStuff() {
            if (Opperation == "a")
            {
                result = Num1 + Num2;
            }
            if (Opperation == "s")
            {
                result = Num1 - Num2;
            }
            if (Opperation == "m")
            {
                result = Num1 * Num2;
            }
            if (Opperation == "d")
            {
                if (Num2 != 0)
                {
                    return Num1 / Num2;
                }
            }
            return result;
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            Controler controler = new Controler();
        }
    }
}

