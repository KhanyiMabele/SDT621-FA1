using System;

namespace EmfuleniMunicipality.Models
{
    public class ServiceRequest
    {
        // Properties
        public string ResidentName { get; set; }              // e.g., "Lindeka Mntambo"
        public string RequestType { get; set; }               // e.g., "Burst Pipe"
        public string PriorityLevel { get; set; }             // e.g., "High", "Medium", "Low"
        public string SeverityLevel { get; set; }             // e.g., "Critical", "Moderate", "Minor"
        public int UrgencyScore { get; set; }                 // e.g., 64
        public double HouseholdImpactScore { get; set; }      // e.g., 360.00
        public TimeSpan EstimatedResolutionTime { get; set; } // e.g., 7 hours

        // Constructor
        public ServiceRequest(
            string residentName,
            string requestType,
            string priorityLevel,
            string severityLevel,
            int urgencyScore,
            double householdImpactScore,
            TimeSpan estimatedResolutionTime)
        {
            ResidentName = residentName;
            RequestType = requestType;
            PriorityLevel = priorityLevel;
            SeverityLevel = severityLevel;
            UrgencyScore = urgencyScore;
            HouseholdImpactScore = householdImpactScore;
            EstimatedResolutionTime = estimatedResolutionTime;
        }

        public ServiceRequest(string? type, string v1, string v2, TimeSpan timeSpan)
        {
        }

        // Method to display request details
        public void DisplayRequestInfo()
        {
            Console.WriteLine("==== Service Report ====");
            Console.WriteLine($"Resident: {ResidentName}");
            Console.WriteLine($"Service Type: {RequestType}");
            Console.WriteLine($"Priority Level: {PriorityLevel}");
            Console.WriteLine($"Severity Level: {SeverityLevel}");
            Console.WriteLine($"Urgency Score: {UrgencyScore}");
            Console.WriteLine($"Household Impact Score: {HouseholdImpactScore}");
            Console.WriteLine($"Estimated Resolution Time: {EstimatedResolutionTime.TotalHours} hours");
        }

        // Method to display municipal summary
        public void DisplayMunicipalSummary()
        {
            Console.WriteLine("\n==== FINAL MUNICIPAL SUMMARY ====");
            Console.WriteLine($"Highest priority issue:");
            Console.WriteLine($"Resident: {ResidentName}");
            Console.WriteLine($"Service Type: {RequestType}");
            Console.WriteLine($"Urgency Score: {UrgencyScore}");
            Console.WriteLine($"Adjusted Resolution: {EstimatedResolutionTime.TotalHours} hours");
            Console.WriteLine($"Household Impact Score: {HouseholdImpactScore}");
            Console.WriteLine("Thank you for using the Emfuleni Municipality Service Desk.");
        }
    }
}
