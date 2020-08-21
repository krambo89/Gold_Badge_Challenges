using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class BadgesUI
    {
        private bool _isRunning = true;
        private readonly BadgesRepository _badgeDictionary = new BadgesRepository();
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
                OpenBadgeList(userInput);
            }
        }
        private string OpenList()
        {
            Console.Clear();
            Console.WriteLine("Welcome! What would you like to do: \n" +
                "1. Add a Badge\n" +
                "2. Edit a Badge\n" +
                "3. List All Badges\n" +
                "4. Exit");

            string userInput = Console.ReadLine();
            return userInput;

        }
        private void OpenBadgeList(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    AddBadgesToDirectory();
                    break;
                case "2":

                    break;
                case "3":
                    DisplayAllBadges();
                    break;
                case "4":
                    _isRunning = false;
                    break;
                default:
                    return;
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private void AddBadgesToDirectory()
        {
            Console.Clear();
            Console.WriteLine("Enter Badge ID: ");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("List the door the badge needs access to: ");
            string roomName = Console.ReadLine();

            Console.WriteLine("Is that the only door you need to add (y/n)");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    Console.WriteLine("List a door that it needs access to.");
                    Console.ReadLine();
                    break;
                case "n":
                    Console.WriteLine("Okay, returning to the main menu.");
                    break;
                default:
                    break;
            }

            Console.WriteLine("Is another door you need to add (y/n)");
            Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    Console.WriteLine("List a door that it needs access to.");
                    Console.ReadLine();
                    break;
                case "n":
                    Console.WriteLine("Okay, returning to the main menu.");
                    break;
                default:
                    break;

            }

            Badges newBadge = new Badges(badgeID, new List<string> { roomName });

            _badgeDictionary.AddBadgesToDirectory(badgeID, new List<string> { roomName });
        }
        private void DisplayAllBadges()
        {
            Dictionary<int, List<string>> listOfbadges = _badgeDictionary.GetBadgeDirectory();

            foreach (KeyValuePair<int, List<string>> badge in listOfbadges)
            {
                string values = "";
                foreach (string instance in badge.Value)
                {
                    values += instance + ",";
                }
                Console.WriteLine($"Badge: {badge.Key}, Door Access: {values}");
            }
        }
        private void SeedMenuItems()
        {
            Badges firstBadge = new Badges(123456, new List<string> { "A7" });
            Badges secondBadge = new Badges(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badges thirdBadge = new Badges(32345, new List<string> { "A4", "A5" });

            _badgeDictionary.AddBadgesToDirectory(123456, new List<string> { "A7" });
            _badgeDictionary.AddBadgesToDirectory(22345, new List<string> { "A1", "A4", "B1", "B2" });
            _badgeDictionary.AddBadgesToDirectory(32345, new List<string> { "A4", "A5" });
        }

    }
}

