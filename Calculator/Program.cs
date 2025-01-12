using System.Text.RegularExpressions;
using CalculatorLibrary;
using Microsoft.VisualBasic;

namespace CalculatorProgram { 
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            //Display title as the C# Console Calculator App
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("--------------------------");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                // Declare variables and set to empty
                // Use Nullable types (with ?) to match type of System .Console.ReadLine()

                string? numInput1 = "";
                string? numInput2 = "";
                double result = 0;
                double result2 = 0;
                int counter = 0;
               
                //Ask the user to type the first number
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while(!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not a valid input. Please enter a numeric value: ");
                    numInput1 = Console.ReadLine();
                }


                // Ask the user to type the second number
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while(!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not a valid input. Please enter a numberic value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Substract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tr - Square Root");
                Console.WriteLine("\tp - Power");
                Console.WriteLine("\tt - 10x");
                Console.WriteLine("\tf - Trigonometry Function");
                Console.WriteLine("\tq - Quit");

                string? op = Console.ReadLine();

                // Validate input is not null, and matches the pattern
                if (op == null || !Regex.IsMatch(op, "[a|s|m|d|r|p|t|f|q]"))
                {
                    Console.WriteLine("Error: Unrecognized input.");
                }    
                else
                {
                    try
                    {
                        result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                        result2 = calculator.SquareRoot(cleanNum2);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        if (op == "r")
                        {
                            Console.WriteLine($"First number:{result}\nSecond number:{result2}\n");
                        }
                        else
                        {
                            Console.WriteLine("Your result: {0:0.##}\n", result);
                        }
                        counter++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occured trying to do the math. \n" + e.Message);
                    } 
                }
                Console.WriteLine("---------------------\n");
                
                // Wait for the user to respond before closing.
                Console.WriteLine($"The calculator has been used {counter} times.");
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); //Friendly linespacing.
            }
            calculator.Finish();
            return;
        }
    }
}