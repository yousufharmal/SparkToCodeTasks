namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        // Task 1 - Countdown Timer
        
        Console.Write("Please enter a number :");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = n; i > 0; i--)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("Liftoff!");
    }
}