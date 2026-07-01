namespace Task1;

class Program
{
    static void Main(string[] args)
    {
       
        
        /*
         
        // Task 1

        string name = "Ahmed";
        int age = 20;
        double height = 1.80;
        bool isStudent =  true;
        
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Height: " + height);
        Console.WriteLine("Student: " + isStudent);
        
        
        // Task 2
        Console.Write("Please enter the length of the rectangle: ");
        float length = float.Parse(Console.ReadLine());
        Console.Write("Please enter the width of the rectangle: ");
        float width = float.Parse(Console.ReadLine());
        
        float area = (length * width);
        float perimeter = (length + width) * 2;
        
        Console.WriteLine($"The area of the rectangle is: {area}");
        Console.WriteLine($"The perimeter of the rectangle is: {perimeter}");
        
        
        // Task 3
        
        Console.Write("Please enter a whole number: ");
        int number = int.Parse(Console.ReadLine());
        
        if (number % 2 == 0) {
            Console.WriteLine("The number is even");
        }
        else {
            Console.WriteLine("The number is odd");
        }
        
        
        
        // Task 4
        
        Console.Write("Please enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Do you have a valid National ID ?");
        String nationalID = Console.ReadLine();

        bool isValidNationalID = nationalID.ToLower() == "yes";

        if (isValidNationalID && age > 18)
        {
            Console.WriteLine("You are eligible to vote!");
        }
        else
        {
            Console.WriteLine("Sorry,you are not eligible to vote!");
        }
        
        */
        
        // Task 5
        
        Console.Write("Please enter your grade ('A', 'B', 'C', 'D', or 'F'): ");
        char grade = char.Parse(Console.ReadLine().ToUpper());

        switch (grade)
        {
            case 'A':
                Console.WriteLine("Your grade is Excellent");
                break;
            case 'B':
                Console.WriteLine("Your grade is Very Good");
                break;
            case 'C':
                Console.WriteLine("Your grade is Good");
                break;
            case 'D':
                Console.WriteLine("Pass");
                break;
            case 'F':
                Console.WriteLine("Fail");
                break;
            default:
                Console.WriteLine("Invalid grade");
                break;
               
        }
        


    }
}