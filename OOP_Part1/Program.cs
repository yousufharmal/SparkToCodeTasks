namespace OOP_Part1;


public class BankAccount
{
    public int AccountNumber { get; set; }
    public string HolderName { get; set; }
    public double Balance { get; set; }
    
    public void Deposit(double amount) 
    {
        Balance += amount;
        SendEmail();
    }

    public void Withdraw(double amount)
    {
        Balance -= amount;
        SendEmail();
    }

    public double CheckBalance()
    {
        PrintInformation();
        return Balance;
    }

    private void PrintInformation()
    {
       
        Console.WriteLine($"Holder Name: {HolderName}");
        Console.WriteLine($"Balance: {Balance}");
    }
    
    private void SendEmail()
    {
        Console.WriteLine("An email has been sent to your email address");
    }
}

public class Student
{
    public int Grade { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    private string email { get; set; } 
    int age { get; set; }


    public void Register(string Email)
    {
        email = Email;
        SendEmail();
    }

    private void SendEmail()
    {
        Console.WriteLine("An email has been sent to your email address");
    }
}

public class Product
{
    public double Price { get; set; }
    public string ProductName { get; set; }
    public int StockQuantity { get; set; }

    public void Sell (int quantity)
    {
        if (StockQuantity >= quantity)
        {
            StockQuantity -= quantity;
        }
        else
        {
            Console.WriteLine("Not enough stock");
        }
        LogTransaction();
    }

    public void Restock(int quantity)
    {
        StockQuantity += quantity;
        LogTransaction();
    }

    public double GetInventoryValue()
    {
        PrintDetails();
        return StockQuantity *  Price;
    }

    private void PrintDetails()
    {
        Console.WriteLine($"Your Product Name: {ProductName}");
        Console.WriteLine($"Your Product Price: {Price}");
        Console.WriteLine($"Your Stock Quantity: {StockQuantity}");
    }

    private void LogTransaction()
    {
        Console.WriteLine($"Transaction recorded for {ProductName}.");
    }
}

public class Program
{
    
    // =========================
    // Bank Accounts
    // =========================

    static BankAccount B1 = new BankAccount
    {
        AccountNumber = 1163,
        HolderName = "Karim",
        Balance = 120
    };

    static BankAccount B2 = new BankAccount
    {
        AccountNumber = 15203,
        HolderName = "Ali",
        Balance = 63
    };

    // =========================
    // Students
    // =========================

    static Student S1 = new Student
    {
        Name = "Ali",
        Address = "Muscat",
        Grade = 65
    };

    static Student S2 = new Student
    {
        Name = "Ahmed",
        Address = "Muscat",
        Grade = 70
    };

    // =========================
    // Products
    // =========================

    static Product P1 = new Product
    {
        ProductName = "Wireless Mouse",
        Price = 5.500,
        StockQuantity = 50
    };

    static Product P2 = new Product
    {
        ProductName = "Mechanical Keyboard",
        Price = 15.750,
        StockQuantity = 20
    };

    static void Main(string[] args)
    {
        /*
        bool exitApp = false;

        while (exitApp == false)
        {
            Console.WriteLine("\n===== OOP Part 1 - Bank / Student / Product Manager =====");
            Console.WriteLine(" 1. View Account Details");
            Console.WriteLine(" 2. Update Student Address");
            Console.WriteLine(" 3. Make a Deposit");
            Console.WriteLine(" 4. Make a Withdrawal");
            Console.WriteLine(" 5. View Product Details");
            Console.WriteLine(" 6. Register a Student");
            Console.WriteLine(" 7. Compare Two Account Balances");
            Console.WriteLine(" 8. Restock Product & Stock Level Check");
            Console.WriteLine(" 9. Transfer Between Accounts");
            Console.WriteLine("10. Update Student Grade (Validated)");
            Console.WriteLine("11. Student Report Card");
            Console.WriteLine("12. Account Health Status");
            Console.WriteLine("13. Bulk Sale With Revenue Calculation");
            Console.WriteLine("14. Scholarship Eligibility Check");
            Console.WriteLine("15. Full Balance Top-Up Flow");
            Console.WriteLine("16. Quick Account Opening (Parameterized Constructor)");
            Console.WriteLine("17. Total Students Counter (Static Field & Method)");
            Console.WriteLine("18. Overdrawn Account Check (Read-Only Property)");
            Console.WriteLine("19. Set Student Security PIN (Write-Only Property)");
            Console.WriteLine("20. Exit");
            Console.Write("Choose an option: ");

            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
                continue;
            }

            switch (choice)
            {
                case 1: ViewAccountDetails(); break;
                case 2: UpdateStudentAddress(); break;
                case 3: MakeDeposit(); break;
                case 4: MakeWithdrawal(); break;
                case 5: ViewProductDetails(); break;
                case 6: RegisterStudent(); break;
                case 7: CompareAccountBalances(); break;
                case 8: RestockProduct(); break;
                case 9: TransferBetweenAccounts(); break;
                case 10: UpdateStudentGrade(); break;
                case 11: StudentReportCard(); break;
                case 12: AccountHealthStatus(); break;
                case 13: BulkSaleWithRevenue(); break;
                case 14: ScholarshipEligibilityCheck(); break;
                case 15: FullBalanceTopUpFlow(); break;
                case 16: QuickAccountOpening(); break;
                case 17: TotalStudentsCounter(); break;
                case 18: OverdrawnAccountCheck(); break;
                case 19: SetStudentSecurityPin(); break;
                case 20:
                    exitApp = true;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose between 1 and 20.");
                    break;
            }

            Console.WriteLine("press any key");
            Console.ReadKey();
            Console.Clear();

        }
        */
    }
    
    // --------------------------- Helpers ---------------------------

    // Lets the user pick account1 or account2
    static BankAccount ChooseAccount()
    {
        Console.Write("Choose account (1 or 2): ");
        string input = Console.ReadLine();
        if (input == "2")
        {
            return B2;
        }
        return B1;
    }
    
    // Lets the user pick student1 or student2
    static Student ChooseStudent()
    {
        Console.Write("Choose student (1 or 2): ");
        string input = Console.ReadLine();
        if (input == "2")
        {
            return S2;
        }
        return S1;
    }

    // Lets the user pick product1 or product2
    static Product ChooseProduct()
    {
        Console.Write("Choose product (1 or 2): ");
        string input = Console.ReadLine();
        if (input == "2")
        {
            return P2;
        }
        return P1;
    }
}