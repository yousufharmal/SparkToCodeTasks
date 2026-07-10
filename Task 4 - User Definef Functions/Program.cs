namespace Task_4___User_Definef_Functions;

class Program
{
    // Task 1 - Personalized Welcome Function
    public static void PrintWelcome(string name)
    {
        Console.WriteLine($"Welcome {name}!");
    }
    
    static void Main(string[] args)
    {
        Console.Write("Please enter your name: ");
        string input = Console.ReadLine();
        PrintWelcome(input);
    }
}