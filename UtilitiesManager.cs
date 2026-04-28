using System;
using System.Collections.Generic;
using System.Linq;
using EmfuleniMunicipality.Models;

namespace EmfuleniMunicipality.Services
{
    public class UtilitiesManager
    {
        private List<ServiceRequest> _requests;

        public UtilitiesManager()
        {
            _requests = new List<ServiceRequest>();
        }

        // Add a new service request
        public void AddRequest(ServiceRequest request)
        {
            _requests.Add(request);
            Console.WriteLine("Service request added successfully.");
        }

        // Calculate urgency score based on priority and severity
        public int CalculateUrgencyScore(ServiceRequest request)
        {
            int priorityWeight = request.PriorityLevel.ToLower() switch
            {
                "high" => 3,
                "medium" => 2,
                "low" => 1,
                _ => 0
            };

            int severityWeight = request.SeverityLevel.ToLower() switch
            {
                "critical" => 3,
                "moderate" => 2,
                "minor" => 1,
                _ => 0
            };

            // Simple formula: urgency = priority + severity
            return priorityWeight + severityWeight;
        }

        // Generate a comprehensive report of all requests
        public void GenerateServiceReport()
        {
            Console.WriteLine("\n--- Service Requests Report ---");

            foreach (var request in _requests)
            {
                int urgencyScore = CalculateUrgencyScore(request);
                Console.WriteLine($"Request Type: {request.RequestType}");
                Console.WriteLine($"Priority: {request.PriorityLevel}");
                Console.WriteLine($"Severity: {request.SeverityLevel}");
                Console.WriteLine($"Estimated Resolution: {request.EstimatedResolutionTime.TotalHours} hours");
                Console.WriteLine($"Urgency Score: {urgencyScore}");
                Console.WriteLine("-----------------------------------");
            }

            // Summary
            Console.WriteLine($"Total Requests: {_requests.Count}");
            Console.WriteLine($"Most Urgent Request: {GetMostUrgentRequest()?.RequestType ?? "None"}");
        }

        // Find the most urgent request
        public ServiceRequest GetMostUrgentRequest()
        {
            return _requests
                .OrderByDescending(r => CalculateUrgencyScore(r))
                .FirstOrDefault();
        }

        internal void AddRequest(ServiceRequest request, Resident associatedResident)
        {
            // Ensure the request and associated resident are not null
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (associatedResident == null) throw new ArgumentNullException(nameof(associatedResident));

            // Add the request to the internal list of requests
            _requests.Add(request);
            // Optionally, you can log or handle the association with the resident here
        }

        internal void DisplayPendingRequests()
        {
            throw new NotImplementedException();
        }

        internal void GenerateSummary()
        {
            throw new NotImplementedException();
        }

        internal bool HasPendingRequests()
        {
            throw new NotImplementedException();
        }

        internal void ProcessRequest(int index)
        {
            throw new NotImplementedException();
        }
    }
}
