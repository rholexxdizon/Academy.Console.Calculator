class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; 

        switch(op)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                while (num2 == 0)
                {
                    Console.WriteLine("Please enter a non-zero divisor: ");
                    result = num1 / num2;
                   
                }
                break;
            default:
                break;

        }
        return result;
    }
}