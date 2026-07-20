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
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}