using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimsUI
    {
        private bool _isRunning = true;
        private readonly ClaimsRepository _claimsDirectory = new ClaimsRepository();
        public void Start()
        {
            SeedMenuItems();
            RunMenu();

        }
        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = OpenList();
                OpenClaimsList(userInput);
            }
        }
        private string OpenList()
        {
            Console.Clear();
            Console.WriteLine("Select an Option: \n" +
                "1. See All Claims\n" +
                "2. Take Care Of Claim\n" +
                "3. Enter New Claim\n" +
                "4. Modify Claim\n" +
                "5. Exit");

            string userInput = Console.ReadLine();
            return userInput;

        }
        private void OpenClaimsList(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayClaims();
                    break;
                case "2":
                    DeleteExistingClaim();
                    break;
                case "3":
                    AddClaimsToDirectory();
                    break;
                case "4":
                    UpdateExistingClaims();
                    break;
                case "5":
                    _isRunning = false;
                    break;
                default:
                    return;
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        private void DisplayClaims()
        {
            Queue<Claims> listOfClaims = _claimsDirectory.GetClaimsDirectory();

            foreach (Claims claim in listOfClaims)
            {
                DisplayClaims(claim);
            }
        }
        private void DisplayClaims(Claims claim)
        {
            Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                $"Claim Type: {claim.ClaimType}\n" +
                $"Description: {claim.Description}\n" +
                $"Claim Amount: {claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Valid Claim: {claim.IsValid}\n");
        }

        public void DeleteExistingClaim()
        {

            if (_claimsDirectory.GetClaimsDirectory().Count > 0)
            {
                Console.Clear();
                var top = _claimsDirectory.GetClaimsDirectory().Peek();
                Console.WriteLine("Here is the Next Claim in the Queue:");
                Console.WriteLine($"ClaimID: {top.ClaimID}\n" +
                $"Claim Type: {top.ClaimType}\n" +
                $"Description: {top.Description}\n" +
                $"Claim Amount: {top.ClaimAmount}\n" +
                $"Date of Incident: {top.DateOfIncident}\n" +
                $"Date of Claim: {top.DateOfClaim}\n" +
                $"Valid Claim: {top.IsValid}\n" +
                $"\n" +
                $"Will you deal with this claim now? (y/n)?");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "y":
                        Console.WriteLine("Case has been DeQueued and assigned.");
                        break;
                    case "n":
                        Console.WriteLine("Okay, returning to the main menu.");
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddClaimsToDirectory()
        {
            Console.Clear();
            Console.Write("Enter Claim ID: ");
            int claimID = int.Parse(Console.ReadLine());

            Console.Write("Enter Claim Type: ");
            string claimType = Console.ReadLine();

            Console.Write("Enter a Description: ");
            string description = Console.ReadLine();

            Console.Write("Amount of Damages: ");
            double claimAmount = double.Parse(Console.ReadLine());

            Console.Write("Date of Incident: ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim: ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            bool isValid = true;
            if ((dateOfIncident - dateOfClaim).TotalDays < 30)
            {
                Console.WriteLine("Claim is Valid.");
            }

            else
            {
                Console.WriteLine("Claim is not valid.");
            }

            Claims newClaim = new Claims(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);

            _claimsDirectory.AddClaimsToDirectory(newClaim);
        }

        private void UpdateExistingClaims()
        {
            Console.Clear();
            DisplayClaims();

            Console.WriteLine("Enter the ClaimID for the Claim you want to update.");
            int originalClaimID = int.Parse(Console.ReadLine());

            Console.Write("Enter Claim ID: ");
            int claimID = int.Parse(Console.ReadLine());

            Console.Write("Enter Claim Type: ");
            string claimType = Console.ReadLine();

            Console.Write("Enter a Description: ");
            string description = Console.ReadLine();

            Console.Write("Amount of Damages: ");
            double claimAmount = double.Parse(Console.ReadLine());

            Console.Write("Date of Incident: ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim: ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            bool isValid = true;
            if ((dateOfIncident - dateOfClaim).TotalDays < 30)
            {
                Console.WriteLine("Claim is Valid.");
            }

            else
            {
                Console.WriteLine("Claim is not valid.");
            }

            Claims newClaim = new Claims(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);

            bool wasUpdated = _claimsDirectory.UpdateExistingClaims(originalClaimID, newClaim);

            if (wasUpdated)
            {
                Console.WriteLine("Content Updated");
            }
            else
            {
                Console.WriteLine("Could Not Update");
            }
        }
        private void SeedMenuItems()
        {
            Claims firstClaim = new Claims(1, "Car", "Car accident on 465.", 400.00, new DateTime(201, 4, 25), new DateTime(2018, 4, 27), true);
            Claims secondClaim = new Claims(2, "Home", "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claims thirdClaim = new Claims(3, "Theft", "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01), false);

            _claimsDirectory.AddClaimsToDirectory(firstClaim);
            _claimsDirectory.AddClaimsToDirectory(secondClaim);
            _claimsDirectory.AddClaimsToDirectory(thirdClaim);
        }

    }
}
