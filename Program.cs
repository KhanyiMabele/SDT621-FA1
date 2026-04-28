using System;
using System.Collections.Generic;
using EmfuleniMunicipality.Models;
using EmfuleniMunicipality.Services;

namespace EmfuleniMunicipality
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Resident> residents = new List<Resident>();
            UtilitiesManager manager = new UtilitiesManager();

            // Step 1: Gather resident information
            Console.Write("Enter number of residents: ");
            int numResidents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numResidents; i++)
            {
                Console.WriteLine($"\nEnter details for Resident {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Address: ");
                string address = Console.ReadLine();

                Console.Write("Account Number: ");
                string accountNumber = Console.ReadLine();

                Console.Write("Monthly Utility Usage (kWh): ");
                double usage = double.Parse(Console.ReadLine());

                residents.Add(new Resident(name, address, accountNumber, usage));
            }

            // Step 2: Gather service requests
            Console.Write("\nEnter number of service requests: ");
            int numRequests = int.Parse(Console.ReadLine());

            for (int i = 0; i < numRequests; i++)
            {
                Console.WriteLine($"\nEnter details for Service Request {i + 1}:");

                Console.Write("Associated Resident (index 1-" + numResidents + "): ");
                int residentIndex = int.Parse(Console.ReadLine()) - 1;
                Resident associatedResident = residents[residentIndex];

                Console.Write("Request Type: ");
                string type = Console.ReadLine();

                Console.Write("Priority Level (1-5): ");
                int priority = int.Parse(Console.ReadLine());

                Console.Write("Severity Level (1-10): ");
                int severity = int.Parse(Console.ReadLine());

                Console.Write("Estimated Resolution Time (hours): ");
                double hours = double.Parse(Console.ReadLine());

                ServiceRequest request = new ServiceRequest(
                    type,
                    priority.ToString(),   // store as string for now
                    severity.ToString(),
                    TimeSpan.FromHours(hours)
                );

                // Attach resident info to request via UtilitiesManager
                manager.AddRequest(request, associatedResident);
            }

            // Step 3: Display queue of pending requests
            Console.WriteLine("\n--- Pending Service Requests ---");
            manager.DisplayPendingRequests();

            // Step 4: Process requests interactively
            while (manager.HasPendingRequests())
            {
                Console.Write("\nSelect a request to process (index): ");
                int index = int.Parse(Console.ReadLine());
                manager.ProcessRequest(index);
            }

            // Step 5: Show summary
            manager.GenerateSummary();
        }
    }
}
