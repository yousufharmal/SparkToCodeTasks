namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        // Task 1 - Countdown Timer
        
        /*
        Console.Write("Please enter a number :");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = n; i > 0; i--)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("Liftoff!");
        */
        
        // Task 2 - Sum of Numbers 1 to N
        Console.Write("Enter a positive whole number: ");
        int number = int.Parse(Console.ReadLine());
        
        
        int sum = 0;

        for (int i = 1; i <= number; i++)
        {
            sum += i;
        }

        Console.WriteLine("The sum is: " + sum);
    }
}