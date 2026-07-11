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
    
    // Task 5 - Even or Odd Function

    public static bool isEven(int n)
    {
        return n % 2 == 0;
    }
    
    // Task 6 - Rectangle Area & Perimeter Functions

    public static double CalculateArea(double n, double m)
    {
        return n * m;
    }

    public static double CalculatePerimeter(double n, double m)
    {
        return n * (m + 2);
    }
    
    // Task 7 - Grade Letter Function

    public static string GetGradeLetter(int grade)
    {
        if (grade >= 80)
        {
            return "A";
        }
        else if (grade >= 70)
        {
            return "B";
        }
        else if (grade >= 60)
        {
            return "C";
        }
        else if (grade >= 50)
        {
            return "D";
        }
        else 
        {
            return "F";
        }
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
        
        
        // Task 4 - Fixed Menu Display Function
        DisplayMenu();
        
        
        // Task 5 - Even or Odd Function
        
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        bool even = isEven(n);

        if (even)
        {
            Console.WriteLine("The number is even");
        }
        else
        {
            Console.WriteLine("The number is odd");
        }
        
        
        // Task 6 - Rectangle Area & Perimeter Functions

        Console.Write("Enter the lenght: ");
        double lenght = double.Parse(Console.ReadLine());
        Console.Write("Enter the width: ");
        double width = double.Parse(Console.ReadLine());

        double area = CalculateArea(lenght, width);
        double perimeter = CalculatePerimeter(lenght, width);
        
        Console.WriteLine("The area is: " + area);
        Console.WriteLine("The perimeter is: " + perimeter);
        
        */
        
        // Task 7 - Grade Letter Function
        
        int grade = -1;

        while (grade < 0 || grade > 100)
        {
            try
            {
                Console.Write("Enter a grade (0-100): ");
                grade = int.Parse(Console.ReadLine());

                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Grade must be between 0 and 100.");
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid whole number.");
            }
        }
        
        string letter = GetGradeLetter(grade);
        Console.WriteLine($"Grade letter: {letter}");
        


    }
}