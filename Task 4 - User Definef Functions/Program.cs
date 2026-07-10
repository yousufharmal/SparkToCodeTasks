namespace Task_4___User_Definef_Functions;

class Program
{
    // Task 1 - Personalized Welcome Function
    
    public static void PrintWelcome(string name)
    {
        Console.WriteLine($"Welcome {name}!");
    }
    
    
    // Task 2 - Square Number Function
    public static int Square(int n)
    {
        return n * n;
    }

    // Task 3 - Celsius to Fahrenheit Function
    public static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }
    
    // Task 4 - Fixed Menu Display Function

    public static void DisplayMenu()
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine("Please choose an option: ");
        Console.WriteLine("1: Start");
        Console.WriteLine("2: Help");
        Console.WriteLine("3: Exit");
    }
    static void Main(string[] args)
    {
        // // Task 1 - Personalized Welcome Function
        /*
        Console.Write("Please enter your name: ");
        string input = Console.ReadLine();
        PrintWelcome(input);
        
        
        // Task 2 - Square Number Function
        Console.Write("Enter a number: ");
        int a = int.Parse(Console.ReadLine());
        Square(a);
        Console.WriteLine($"The square of {a} is: {Square(a)}");
        
        
        // Task 3 - Celsius to Fahrenheit Function
        
        Console.Write("Please enter the temperature in Celsius: ");
        double celsius = double.Parse(Console.ReadLine());
        Console.WriteLine($"The temperature in Fehrenheit is {CelsiusToFahrenheit(celsius)}");
        */
        
        // Task 4 - Fixed Menu Display Function
        DisplayMenu();
        
        
    }
}