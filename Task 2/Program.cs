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
        
        
        // Task 2 - Sum of Numbers 1 to N
        Console.Write("Enter a positive whole number: ");
        int number = int.Parse(Console.ReadLine());
        
        
        int sum = 0;

        for (int i = 1; i <= number; i++)
        {
            sum += i;
        }

        Console.WriteLine("The sum is: " + sum);
        
        
        // Task 3 - Multiplication Table
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());

       
        for (int i =1; i<=10; i++)
        {
            Console.WriteLine(number + " x " + i + " = " + number*i);
        }
        
        
        
        // Task 4 - Password Retry

        string correctPassword = "Spark2026";
        string password = "";

        while (password != correctPassword)
        {
            Console.Write("Enter the password: ");
            password = Console.ReadLine();

            if (password != correctPassword)
            {
                Console.WriteLine("Incorrect password, try again");
            }
        }

        Console.WriteLine("Access Granted");
        
        */
        
        // Task 5 - Number Guessing Game

        int secretNumber = 78;
        int guess;
        int attempts = 0;

        do
        {
            Console.Write("Guess the secret number: ");
            guess = int.Parse(Console.ReadLine());

            attempts++;

            if (guess > secretNumber)
            {
                Console.WriteLine("Too high");
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Too low");
            }
            else
            {
                Console.WriteLine("Correct!");
            }

        } while (guess != secretNumber);

        Console.WriteLine("You guessed the number in " + attempts + " attempts.");
    }
}