using System.Security.Cryptography;

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
        
        
        // Task 3 - Name Formatter //////////////
        
        Console.WriteLine("Please enter your full name: ");
        string fullName = Console.ReadLine();
        
        Console.WriteLine("Your full name in capital letters: " + fullName.ToUpper());
        Console.WriteLine("Your full name in small letters: " + fullName.ToLower());
        Console.WriteLine($"Your name contains {fullName.Length} letters" );
        
        /////////////////////////////////////////////////
        
        
        // Task 4 - Subscription End Date //////////////
        
        Console.Write("Enter the number of days for the free trial: ");
        int trialDays = int.Parse(Console.ReadLine());

        DateTime startDate = DateTime.Today;
        DateTime endDate = startDate.AddDays(trialDays);

        Console.WriteLine("The trial ends on: " + endDate.ToString("yyyy-MM-dd"));
        
        /////////////////////////////////////////////////
        
        
        // Task 5 - Grade Rounding System //////////////
        
        Console.Write("Enter your raw exam score as decimal: ");
        double rawScore = double.Parse(Console.ReadLine());
        
        double roundedScore = Math.Round(rawScore, 0);

        if (roundedScore >= 60)
        {
            Console.WriteLine("Congrats! You have passed ");
        }
        else
        {
            Console.WriteLine("Sorry, you do not pass ");
        }
        
        Console.WriteLine("Your rounded score is " + roundedScore);
        
        /////////////////////////////////////////////////
        
        
        // Task 6 - Password Strength Checker //////////////
        
        string password;
        bool validPassword;

        do
        {
            Console.Write("Enter a password: ");
            password = Console.ReadLine();

            validPassword =
                password.Length >= 8 &&
                !password.ToLower().Contains("password");

            if (validPassword)
            {
                Console.WriteLine("Strong");
            }
            else
            {
                Console.WriteLine("Weak");

                if (password.Length < 8)
                    Console.WriteLine("- Password must be at least 8 characters long.");

                if (password.ToLower().Contains("password"))
                    Console.WriteLine("- Password must not contain the word \"password\".");
            }

        } while (!validPassword);
        
        /////////////////////////////////////////////////
        
        
        // Task 7 - Clean Name Comparator //////////////
        
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine().Trim().ToLower();
        Console.WriteLine("Please confirm your name again: ");
        string nameConfirmed = Console.ReadLine().Trim().ToLower();

        if (name == nameConfirmed)
        {
            Console.WriteLine("Match");
        }
        else
        {
            Console.WriteLine("No match");
        }
        
        /////////////////////////////////////////////////
        
        
        // Task 8 - Membership Expiry Checker //////////////
        
        try
        {
            Console.Write("Enter the membership start date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter the number of valid membership days: ");
            int validDays = int.Parse(Console.ReadLine());

            DateTime expiryDate = startDate.AddDays(validDays);

            if (expiryDate >= DateTime.Today)
            {
                Console.WriteLine("Membership Status: Active");
            }
            else
            {
                Console.WriteLine("Membership Status: Expired");
            }

            Console.WriteLine("Expiry Date: " +
                              expiryDate.ToString("yyyy-MM-dd"));
        }
        catch
        {
            Console.WriteLine("Invalid input. Please enter a valid date and number.");
        }
        
        /////////////////////////////////////////////////
        */
        
        // Task 9 - Round Up / Round Down Explorer //////////////
        
        Console.Write("Enter a decimal number: ");
        double number = double.Parse(Console.ReadLine());

        double rounded = Math.Round(number);
        double roundedUp = Math.Ceiling(number);
        double roundedDown = Math.Floor(number);

        Console.WriteLine($"Nearest whole number: {rounded}");
        Console.WriteLine($"Always rounded up:    {roundedUp}");
        Console.WriteLine($"Always rounded down:  {roundedDown}");
    }
}