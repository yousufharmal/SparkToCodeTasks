namespace Task3;

class Program
{
    static void Main(string[] args)
    {
        // Task 1 - Absolute Difference //////////////
        
        Console.Write("Please enter your first number: ");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Please enter your second number: ");
        double secondNumber = double.Parse(Console.ReadLine());
        
        double subtraction = firstNumber - secondNumber;
        double absoulute = Math.Abs(subtraction);
        
        Console.WriteLine("Your final positive difference is: " + absoulute);
        
        
    }
}