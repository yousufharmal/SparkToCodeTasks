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
    
    // Task 8 - Countdown Function

    public static void Countdown(int number)
    {
        Console.WriteLine("Your countdown is starting");
        for (int i = 1; i <= number; number--)
        {
            Console.WriteLine(number);
        }
    }
    
    // Task 9 - Overloaded Multiply Function

    public static int Multiply(int x, int y)
    {
        return x * y;
    }

    public static double Multiply(double x, double y)
    {
        return x * y;
    }
    
    public static int Multiply(int x, int y, int z)
    {
        return x * y * z;
    }
    
    // Task 10 - Overloaded Area Calculator
    
    public static double CalculateArea(double n)
    {
        return n * n;
    }
     // The second function is already declared above ( line 45 )
    
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
        
        
        
        // Task 8 - Countdown Function
        
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        
        Countdown(n);
        
        
        
        // Task 9 - Overloaded Multiply Function

        int n = Multiply(2, 3);
        double m = Multiply(3.977, 4.985);
        int x = Multiply(2, 3, 5);
        
        Console.WriteLine("The first multiply function with 2 inputs and returning an integer: " + n);
        Console.WriteLine("The second multiply function with 2 inputs and returning a double: " + m);
        Console.WriteLine("The third multiply function with 3 inputs and returning an integer: " + x);

        */
        
        // Task 10 - Overloaded Area Calculator
        bool validChoice = false;

        while (!validChoice)
        {
            Console.Write("Choose a shape (1 = Square, 2 = Rectangle): ");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        double side;
                        while (true)
                        {
                            try
                            {
                                Console.Write("Enter the side length: ");
                                side = double.Parse(Console.ReadLine());

                                if (side > 0)
                                    break;

                                Console.WriteLine("Length must be positive.");
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a valid number.");
                            }
                        }

                        Console.WriteLine($"Area = {CalculateArea(side)}");
                        validChoice = true;
                        break;

                    case 2:
                        double length, width;

                        while (true)
                        {
                            try
                            {
                                Console.Write("Enter the length: ");
                                length = double.Parse(Console.ReadLine());

                                Console.Write("Enter the width: ");
                                width = double.Parse(Console.ReadLine());

                                if (length > 0 && width > 0)
                                    break;

                                Console.WriteLine("Both values must be positive.");
                            }
                            catch
                            {
                                Console.WriteLine("Please enter valid numbers.");
                            }
                        }

                        Console.WriteLine($"Area = {CalculateArea(length, width)}");
                        validChoice = true;
                        break;

                    default:
                        Console.WriteLine("Please enter 1 or 2.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }

    }
}