using System;

class Account
{
    // Step 1: Define properties
    string AccountNumber;
    float Balance;
    string OwnerName;

    // Step 2: Constructor
    public Account(string accNumber, string ownerName)
    {
        AccountNumber = accNumber;
        OwnerName = ownerName;
        Balance = 0;
    }

    // Deposit method
    public void Deposit(float amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited: ${amount:F2}");
        Console.WriteLine($"Account Balance: ${Balance:F2}");
    }

    // Withdraw method
    public void Withdraw(float amount)
    {
        Balance -= amount;
        Console.WriteLine($"Withdrew: ${amount:F2}");
        Console.WriteLine($"Account Balance: ${Balance:F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Step 3
        Console.WriteLine("Enter account number:");
        string accnum = Console.ReadLine()!;

        // Step 4
        Console.WriteLine("Enter owner name:");
        string ownername = Console.ReadLine()!;

        // Step 5
        Account account = new Account(accnum, ownername);

        // Step 6 (fixed amounts as per expected output)
        account.Deposit(100);
        account.Withdraw(50);
    }
}
