using _02_KomodoClaimsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsConsoleApp
{
    public class ProgramUI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Komodo Insurance\n" +
                    "1. See all Claims\n" +
                    "2. Get next claim.\n" +
                    "3. Add a new claim.\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        SeeAllClaims();
                        Console.Clear();
                        RunMenu();
                        break;
                    case "2":
                        GetNextClaim();
                        Console.Clear();
                        RunMenu();
                        break;
                    case "3":
                        AddNewClaim();
                        Console.Clear();
                        RunMenu();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }

        public void SeeAllClaims()
        {
            Queue<Claim> claimList = _claimRepo.GetAllClaims();

            Console.WriteLine("ClaimID     Type     DateOfIncident     DateOfClaim     IsValid     ClaimAmount     Description\n");
            foreach (Claim claim in claimList)
            {
                Console.WriteLine($"{claim.ClaimID}     {claim.ClaimType}     {claim.DateOfIncident}     {claim.DateOfClaim}     {claim.IsValid}     {claim.ClaimAmount}     {claim.Description}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void AddNewClaim()
        {
            Claim claim = new Claim();

            Console.WriteLine("Enter some details about the new claim.\n" +
                "Please enter a claim ID");
            claim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please select a claim type.\n" +
                "1. Car" +
                "2. Home" +
                "3. Theft");

            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
            }

            Console.WriteLine("Please enter the date of the incident");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the claim");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the claim amount");
            claim.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a description of the claim.");
            claim.Description = Console.ReadLine();

            _claimRepo.IsValid(claim);

            _claimRepo.AddClaimToDirectory(claim);

            Console.Clear();
            Console.WriteLine($"You have successfully added claim id: {claim.ClaimID} to the queue.\n" +
                $"Press any key to continue...");
        }
        public void GetNextClaim()
        {
            Console.WriteLine("Here is the next claim in the queue.");

            Queue<Claim> queueList = _claimRepo.GetAllClaims();
            Claim nextClaim = queueList.Peek();

            Console.WriteLine($"ID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                $"Description: {nextClaim.Description}\n\n" +
                $"Do you want to take this claim? Enter the digit 1 or 2. \n" +
                $"1. Yes" +
                $"2. No");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    queueList.Dequeue();
                    Console.WriteLine("You accepted the claim.\n" +
                        "Press any key to continue...");
                    break;
                case "2":
                    Console.WriteLine("You did not accept the claim.\n" +
                        "Press any key to continue...");
                    break;
                default:
                    Console.WriteLine("You didn't enter either 1 or 2.");
                    break;
            }
            Console.ReadLine();

        }

    }
}
