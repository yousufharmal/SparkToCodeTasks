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


        // Task 6
        Console.Write("Enter the temperature in Celsius: ");
        double celsius = double.Parse(Console.ReadLine());
        double fahrenheit = (celsius * 9 / 5) + 32;

        if (celsius < 10)
        {
            Console.WriteLine("The weather is Cold");
        }
        else if (celsius >= 10 && celsius < 30)
        {
            Console.WriteLine("The weather is Mild");
        }
        else
        {
            Console.WriteLine("The weather is Hot");
        }

        Console.WriteLine($"The weather is {fahrenheit} fahrenheit.");



        // Task 7

        Console.Write("Please enter your age: ");
        int age = int.Parse(Console.ReadLine());

        if (age > 0 && age <= 12)
        {
            Console.WriteLine("You are a Child, Your movie ticket price is : 2.000OMR");

        }
        else if (age >= 13 && age <= 59)
        {
            Console.WriteLine("You are an Adult, Your movie ticket price is : 5.000OMR");
        }
        else  if (age >= 60)
        {
            Console.WriteLine("You are a Senior, Your movie ticket price is : 3.000OMR");
        }



        // Task 8

        Console.Write("Please enter your total bill amount OMR: ");
        double amount = double.Parse(Console.ReadLine());

        Console.Write("Are you a loyalty member? yes/no: ");
        string userInput = Console.ReadLine().ToLower();
        double discount = 0;
        if (userInput == "yes" && amount > 20)
        {
             discount = amount * 0.15;

        }


        Console.WriteLine("The original bill in OMR: " + amount);
        Console.WriteLine("The discount amount in OMR: " + discount);
        double total = amount - discount;
        Console.WriteLine("The total bill in OMR: " + total);


        // Task 9
        Console.WriteLine("Please enter a number between 1 and 7: ");
        int number = int.Parse(Console.ReadLine());

        switch (number)
        {
            case 1:
                Console.WriteLine("Today is Sunday!");
                break;
            case 2:
                Console.WriteLine("Today is Monday!");
                break;
            case 3:
                Console.WriteLine("Today is Tuesday!");
                break;
            case 4:
                Console.WriteLine("Today is Wednesday!");
                break;
            case 5:
                Console.WriteLine("Today is Thursday!");
                break;
            case 6:
                Console.WriteLine("Today is Friday!");
                break;
            case 7:
                Console.WriteLine("Today is Saturday!");
                break;
            default:
                Console.WriteLine("Invalid day number!");
                break;
        }



        // Task 10

        Console.Write("please enter the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("please enter the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("please choose an operator (+, -, *, /, or %): ");
        string operatorString = Console.ReadLine();

        switch (operatorString)
        {
            case "+":
                Console.WriteLine(firstNumber + secondNumber);
                break;
            case "-":
                Console.WriteLine(firstNumber - secondNumber);
                break;
            case "*":
                Console.WriteLine(firstNumber * secondNumber);
                break;
            case "/":
                if (secondNumber == 0)
                {
                    Console.WriteLine("Cannot divide by zero.");
                }
                else
                {
                    Console.WriteLine(firstNumber / secondNumber);
                }
                break;
            case "%":
                if (secondNumber == 0)
                {
                    Console.WriteLine("Cannot modolue by zero.");
                }
                else
                {
                    Console.WriteLine(firstNumber % secondNumber);
                }
                break;
            default:
                Console.WriteLine("Invalid operator.");
                break;
        }
        

        // Task 11

        Console.Write("please enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Please enter your monthly income: ");
        float monthlyIncome = float.Parse(Console.ReadLine());
        Console.Write("Do you have an existing loan ? yes/no ");
        string existingLoan = Console.ReadLine().ToLower();

        bool isLoan = existingLoan == "yes" || existingLoan == "y";

        if (!isLoan && monthlyIncome >= 400 && age >= 21 && age <= 60)
        {
            Console.WriteLine("You are eligible for a loan");
        }
        else if (isLoan)
        {
            Console.WriteLine("You are not eligible for a loan because you have an existing loan!");
        }
        else if (monthlyIncome < 400)
        {
            Console.WriteLine("You are not eligible for a loan because your monthly income is less than 400 OMR!");
        }
        else if (age < 21)
        {
            Console.WriteLine("You are not eligible for a loan because you are younger than 21!");
        }
        else if (age > 60)
        {
            Console.WriteLine("You are not eligible for a loan because you are older than 60!");
        }
        
        
        
        // Task 12
        
        Console.Write("Please enter a region code ('A' for local, 'B' for national, 'C' for international): ");
        char regionCode = char.Parse(Console.ReadLine().ToUpper());
        Console.WriteLine("Please enter the package weight in KG: ");
        double weight = double.Parse(Console.ReadLine());
        double baseCost = 0.000;
        double extraCost = 0.000;
        switch (regionCode)
        {
            case 'A':
                baseCost = 1.000;
                if (weight > 10)
                {
                    extraCost = 5.000;
                }
                else if (weight > 5)
                {
                    extraCost = 2.000;
                }
                else
                {
                    extraCost = 0.000;
                }
                break;
            case 'B':
                baseCost = 3.000;
                if (weight > 10)
                {
                    extraCost = 5.000;
                }
                else if (weight > 5)
                {
                    extraCost = 2.000;
                }
                else
                {
                    extraCost = 0.000;
                }
                break;
            
            case 'C':
                baseCost = 7.000;
                if (weight > 10)
                {
                    extraCost = 5.000;
                }
                else if (weight > 5)
                {
                    extraCost = 2.000;
                }
                else
                {
                    extraCost = 0.000;
                }
                break;
            default:
                Console.WriteLine("Invalid region code");
                break;
            
                
        }
        
        Console.WriteLine($"Base cost: {baseCost:F3} OMR");
        Console.WriteLine($"Extra charge: {extraCost:F3} OMR");
        double totalCost = baseCost + extraCost;
        Console.WriteLine($"Total shipping cost: {totalCost:F3} OMR");
        
        

        // Task 13
        Console.Write("Please enter the length of the first side of the triangle: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please enter the length of the second side of the triangle: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Please enter the length of the third side of the triangle: ");
        double c = double.Parse(Console.ReadLine());

        double d = a + b;
        double e = a + c;
        double f = b + c;

        bool isTringaleValid = (d > c && e > b && f > a);

        if (!isTringaleValid)
        {
            Console.WriteLine("This is an invalid triangle");
        }
        else 
        {
            Console.WriteLine("This is a valid triangle");

            if (a == b && b == c)
            {
                Console.WriteLine("This is an Equal triangle");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("This is an Isosceles triangle");
            }
            else
            {
                Console.WriteLine("This is a Scalene triangle");
            }
            
            
        }
        
        */
        
        // Task 14
        
        Console.Write("Please select a product code (1, 2, or 3): ");
        int productCode = int.Parse(Console.ReadLine());
        Console.Write("How many pieces would you like to purchase? ");
        double numberOfPieces = double.Parse(Console.ReadLine());
        Console.Write("Do you have a discount coupon ? yes/no: ");
        string discountCoupon = Console.ReadLine().ToLower();


        String productName = "";
        double productPrice = 0.000;

        switch (productCode)
        {
            case 1:
                productName = "Headphones";
                productPrice = 8.500;
                break;
            case 2:
                productName = "Keyboards";
                productPrice = 12.000;
                break;
            case 3:
                productName = "Mouse";
                productPrice = 5.000;
                break;
            default:
                Console.WriteLine("Invalid product code");
                return;
        }

        double subTotal = numberOfPieces * productPrice;
        double discount = 0.000;
        double totalAmount = subTotal;
        if (discountCoupon == "yes" && subTotal > 20)
        {
            discount = subTotal * 0.10;
            
            totalAmount = subTotal -  discount;
        }

        double tax = totalAmount * 0.05;
        
        totalAmount += tax;
        
        Console.WriteLine("You have successfully bought: " + productName);
        Console.WriteLine($"Subtotal: {subTotal:F3} OMR");
        Console.WriteLine($"Discount: {discount:F3} OMR");
        Console.WriteLine($"Tax: {tax:F3} OMR");
        Console.WriteLine($"Total: {totalAmount:F3} OMR");
        
        // added a branch
        
        


    }
}