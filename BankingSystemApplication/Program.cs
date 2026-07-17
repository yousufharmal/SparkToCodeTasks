using System;
using System.Collections.Generic;

namespace BankingSystemApplication
{
    internal class Program
    {
        // Shared data storage - declared at class level (static) so that
        // EVERY function below can read and modify the same three lists
        // without needing them passed in as parameters.
        static List<string> customerNames = new List<string>();
        static List<string> accountNumbers = new List<string>();
        static List<double> balances = new List<double>();

        static void Main(string[] args)
        {
            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\n===== Welcome to Spark Bank =====");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Transfer Amount");
                Console.WriteLine("6. List All Accounts");
                Console.WriteLine("7. Find Richest Customer");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue; // skip the rest of this loop pass, show the menu again
                }

                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        TransferAmount();
                        break;
                    case 6:
                        ListAllAccounts();
                        break;
                    case 7:
                        FindRichestCustomer();
                        break;
                    case 8:
                        exitApp = true;
                        Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 8.");
                        break;
                }
            }
        }

        // ===================== SERVICE FUNCTIONS =====================
        // Each function owns ONE service end-to-end: it asks the user for
        // whatever it needs, validates it, updates the shared lists, and
        // prints the outcome. Main never reads input or prints results
        // for these services - it only shows the menu and calls them.

        static void AddAccount()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: customer name cannot be empty.");
                return;
            }

            Console.Write("Enter new account number (8 digits): ");
            string accNum = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(accNum) || accNum.Length != 8 || !IsAllDigits(accNum))
            {
                Console.WriteLine("Error: account number must be exactly 8 digits.");
                return;
            }

            // Make sure the account number isn't already taken.
            if (accountNumbers.Contains(accNum))
            {
                Console.WriteLine($"Error: account number '{accNum}' already exists.");
                return;
            }

            double initialDeposit;
            Console.Write("Enter initial deposit amount: ");
            try
            {
                initialDeposit = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: deposit amount must be a valid number.");
                return;
            }

            if (initialDeposit < 0)
            {
                Console.WriteLine("Error: initial deposit cannot be negative.");
                return;
            }

            customerNames.Add(name);
            accountNumbers.Add(accNum);
            balances.Add(initialDeposit);

            Console.WriteLine(
                $"Account created! Customer: {name}, Account #: {accNum}, Balance: {FormatOMR(initialDeposit)}");
        }

        // Helper: checks that every character in the string is a digit 0-9.
        static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        // Helper method for formatting the balance  
        static string FormatOMR(double amount)
        {
            return $"{amount:N3} OMR";
        }


        static void DepositMoney()
        {
            Console.Write("Enter account number: ");
            string accNum = Console.ReadLine();

            int index = accountNumbers.IndexOf(accNum);
            if (index == -1)
            {
                Console.WriteLine($"Error: account number '{accNum}' not found.");
                return;
            }

            double amount;
            Console.Write("Enter deposit amount: ");
            try
            {
                amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: deposit amount must be a valid number.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Error: deposit amount must be positive.");
                return;
            }

            balances[index] += amount;
            Console.WriteLine(
                $"Deposit successful. New balance for {customerNames[index]} ({accNum}): {FormatOMR(balances[index])}");
        }

        static void WithdrawMoney()
        {
            Console.Write("Enter account number: ");
            string accNum = Console.ReadLine();

            int index = accountNumbers.IndexOf(accNum);
            if (index == -1)
            {
                Console.WriteLine($"Error: account number '{accNum}' not found.");
                return;
            }

            double withdrawAmount;
            Console.Write("Enter withdraw amount: ");

            try
            {
                withdrawAmount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: withdraw amount must be a valid number.");
                return;
            }

            if (withdrawAmount <= 0)
            {
                Console.WriteLine("Error: withdraw amount must be positive.");
                return;
            }

            if (withdrawAmount > balances[index])
            {
                Console.WriteLine("Error: You don't have enough money.");
                return;
            }

            balances[index] -= withdrawAmount;
            Console.WriteLine($" Withdraw successful. New balance for {customerNames[index]} ({accNum}): {FormatOMR(balances[index])}");



        }

        static void ShowBalance()
        {
            int index;
            string accNum;

            do
            {
                Console.Write("Enter account number: ");
                accNum = Console.ReadLine();

                index = accountNumbers.IndexOf(accNum);
                if (index == -1)
                {
                    Console.WriteLine($"Error: account number '{accNum}' not found.");

                }
            } while (index == -1);


            Console.WriteLine($"The balance for  {customerNames[index]} ({accNum}): {FormatOMR(balances[index])}");

        }

        static void TransferAmount()
        {
            Console.Write("Enter sender's account number: ");
            string senderAccNum = Console.ReadLine();
            int index1 = accountNumbers.IndexOf(senderAccNum);

            Console.Write("Enter receiver's account number: ");
            string receiverAccNum = Console.ReadLine();
            int index2 = accountNumbers.IndexOf(receiverAccNum);
            
            if (index1 == -1)
            {
                Console.WriteLine($"Error: account number '{senderAccNum}' not found.");
                return;
            }

            if (index2 == -1)
            {
                Console.WriteLine($"Error: account number '{receiverAccNum}' not found.");
                return;
            }
            
            Console.Write("Please enter the amount you want to transfer: ");
            double amount;
            try
            {
                 amount = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: amount must be a valid number.");
                return;
            }

            if (amount > balances[index1])
            {
                Console.WriteLine("Error: You don't have enough money.");
                return;
            }
            
            if (amount <= 0)
            {
                Console.WriteLine("Error: transfer amount must be positive.");
                return;
            }
            
            balances[index1] -= amount;
            balances[index2] += amount;
            
            Console.WriteLine("Transfer Successful!");
            Console.WriteLine($"New balance for sender ({customerNames[index1]}) ({senderAccNum}): {FormatOMR(balances[index1])}");
            Console.WriteLine($"New balance for receiver ({customerNames[index2]}) ({receiverAccNum}): {FormatOMR(balances[index2])}");
            

            

           
            
            
        }
        
        // Custom Service 1: List All Accounts
        // Prints every account currently stored, in a simple table.
        static void ListAllAccounts()
        {
            if (customerNames.Count == 0)
            {
                Console.WriteLine("There are no accounts in the system yet.");
                return;
            }
 
            Console.WriteLine("\n--- All Accounts ---");
            for (int i = 0; i < customerNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {customerNames[i]}, Account #: {accountNumbers[i]}, Balance: {FormatOMR(balances[i])}");
            }
        }
        
        // Custom Service 2: Find Richest Customer
        // Scans the balances list to find the largest balance and reports
        // who holds it.
        static void FindRichestCustomer()
        {
            if (customerNames.Count == 0)
            {
                Console.WriteLine("There are no accounts in the system yet.");
                return;
            }
 
            int richestIndex = 0;
            for (int i = 1; i < balances.Count; i++)
            {
                if (balances[i] > balances[richestIndex])
                {
                    richestIndex = i;
                }
            }
 
            Console.WriteLine($"Richest customer: {customerNames[richestIndex]}, Account #: {accountNumbers[richestIndex]}, Balance: {FormatOMR(balances[richestIndex])}");
        }
    }
}