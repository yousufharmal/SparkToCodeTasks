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
    static void Main(string[] args)
    {
        // // Task 1 - Personalized Welcome Function
        /*
        Console.Write("Please enter your name: ");
        string input = Console.ReadLine();
        PrintWelcome(input);
        */
        
        // Task 2 - Square Number Function
        Console.Write("Enter a number: ");
        int a = int.Parse(Console.ReadLine());
        Square(a);
        Console.WriteLine($"The square of {a} is: {Square(a)}");
    }
}