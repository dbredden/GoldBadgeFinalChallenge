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
            SeedClaims();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Insurance Claims Deptartment\n\n" +
                    "Take an action based on the menu below\n\n" +
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
            var header = new StringBuilder();
            header.Append(String.Format("{0,-10} {1,-12} {2,-15} {3,-12} {4,-16} {5,-16} {6,-12}\n", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid"));
            Console.WriteLine(header);
            foreach (Claim claim in claimList)
            {
                DisplayClaims(claim);
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
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

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

            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                $"Claim Type: {nextClaim.ClaimType}\n" +
                $"Date of Incident: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                $"Claim Description: {nextClaim.Description}\n\n" +
                $"Do you want to take this claim? Enter the digit 1 or 2. \n" +
                $"1. Yes\n" +
                $"2. No\n");

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

        public void DisplayClaims(Claim claim)
        {
            var sb = new StringBuilder();
            sb.Append(String.Format("{0,-10} {1,-12} {2,-15} {3,-12} {4, -16} {5,-16} {6,-12}\n", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount, claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid));
            Console.WriteLine(sb);
        }

        public void SeedClaims()
        {
            Claim claimOne = new Claim(1, ClaimType.Home, "roof damage", 200, DateTime.Parse("09/21/2021"), DateTime.Parse("09/25/2021"), true);
            Claim claimTwo = new Claim(2, ClaimType.Car, "car damage", 300, DateTime.Parse("09/26/2021"), DateTime.Parse("09/30/2021"), true);
            Claim claimThree = new Claim(3, ClaimType.Theft, "car theft", 5000, DateTime.Parse("09/01/2021"), DateTime.Parse("11/1/2021"), false);

            _claimRepo.AddClaimToDirectory(claimOne);
            _claimRepo.AddClaimToDirectory(claimTwo);
            _claimRepo.AddClaimToDirectory(claimThree);
        }

    }
}
