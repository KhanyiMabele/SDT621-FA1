using System;

namespace EmfuleniMunicipality
{
    public class Resident
    {
        // Properties
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public double MonthlyUtilityUsage { get; set; }

        // Constructor
        public Resident(string name, string address, string accountNumber, double monthlyUtilityUsage)
        {
            Name = name;
            Address = address;
            AccountNumber = accountNumber;
            MonthlyUtilityUsage = monthlyUtilityUsage;
        }

        // Method to display resident details
        public void DisplayResidentInfo()
        {
            Console.WriteLine("Resident Information:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Monthly Utility Usage: {MonthlyUtilityUsage} kWh");
        }

        // Method to update utility usage
        public void UpdateUtilityUsage(double newUsage)
        {
            MonthlyUtilityUsage = newUsage;
            Console.WriteLine($"Utility usage updated to {MonthlyUtilityUsage} kWh.");
        }
    }
}
