using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Simple ATM Withdrawal Simulator\n");

        decimal balance = ReadDecimal("Enter your current account balance: ", min: 0m);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"Current balance: {balance:C}");

            decimal amount = ReadDecimal("Enter amount to withdraw: ", min: 0.01m);

            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal. Transaction cancelled.");
            }
            else
            {
                decimal previousBalance = balance;
                balance -= amount;

                PrintReceipt(amount, previousBalance, balance);
            }

            Console.WriteLine();
            if (!ReadYesNo("Do you want to perform another transaction? (Y/N): "))
            {
                Console.WriteLine("Thank you for using the ATM Simulator. Goodbye.");
                break;
            }
        }
    }

    static decimal ReadDecimal(string prompt, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
                continue;
            }

            // Allow culture-invariant decimal entry (both dot and comma)
            if (!decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value) &&
                !decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                Console.WriteLine("Invalid number format. Please enter a valid amount (e.g., 100 or 100.50).");
                continue;
            }

            if (value < min)
            {
                Console.WriteLine($"Value must be at least {min:C}.");
                continue;
            }

            if (value > max)
            {
                Console.WriteLine($"Value must be at most {max:C}.");
                continue;
            }

            return Math.Round(value, 2);
        }
    }

    static bool ReadYesNo(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var key = Console.ReadKey(intercept: true);
            Console.WriteLine(key.KeyChar);
            char c = char.ToUpperInvariant(key.KeyChar);
            if (c == 'Y') return true;
            if (c == 'N') return false;
            Console.WriteLine("Please press Y or N.");
        }
    }

    static void PrintReceipt(decimal amount, decimal previousBalance, decimal updatedBalance)
    {
        Console.WriteLine();
        Console.WriteLine("---------- TRANSACTION RECEIPT ----------");
        Console.WriteLine($"Transaction ID : {Guid.NewGuid()}");
        Console.WriteLine($"Date / Time     : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"Transaction     : Withdrawal");
        Console.WriteLine($"Amount          : {amount:C}");
        Console.WriteLine($"Previous Balance: {previousBalance:C}");
        Console.WriteLine($"Updated Balance : {updatedBalance:C}");
        Console.WriteLine("-----------------------------------------");
    }
}