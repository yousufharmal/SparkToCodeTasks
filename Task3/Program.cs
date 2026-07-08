namespace Task3;

class Program
{
    static void Main(string[] args)
    {
        
        /*
        // Task 1 - Absolute Difference //////////////
        
        Console.Write("Please enter your first number: ");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Please enter your second number: ");
        double secondNumber = double.Parse(Console.ReadLine());
        
        double subtraction = firstNumber - secondNumber;
        double absoulute = Math.Abs(subtraction);
        
        Console.WriteLine("Your final positive difference is: " + absoulute);
        
        /////////////////////////////////////////////////
        
        
        // Task 2 - Power & Root Explorer //////////////
        
        Console.Write("Please enter a number: ");
        double number = double.Parse(Console.ReadLine());
        
        double power = Math.Pow(number, 2);
        double sqrt = Math.Sqrt(number);
        
        Console.WriteLine("The power of 2 of your number = " + power);
        Console.WriteLine("The square root of your number = " + sqrt);
        
        
        /////////////////////////////////////////////////
        */
        
        // Task 3 - Name Formatter //////////////
        
        Console.WriteLine("Please enter your full name: ");
        string fullName = Console.ReadLine();
        
        Console.WriteLine("Your full name in capital letters: " + fullName.ToUpper());
        Console.WriteLine("Your full name in small letters: " + fullName.ToLower());
        Console.WriteLine($"Your name contains {fullName.Length} letters" );

        
    }
}