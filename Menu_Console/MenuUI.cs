using GoldBadge_Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Console
{
    public class MenuUI
    {
        private bool _isRunning = true;
        private readonly MenuRepository _menuRepo = new MenuRepository();
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
                OpenMenuItem(userInput);
            }
        }
        private string OpenList()
        {
            Console.Clear();
            Console.WriteLine("Select an Option: \n" +
                "1. Show Cafeteria Menu\n" +
                "2. Add Menu Items\n" +
                "3. Remove Menu Items\n" +
                "4. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }
        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayMenu();
                    break;
                case "2":
                    CreateNewItem();
                    break;
                case "3":
                    DeleteExistingItem();
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
        private void DisplayMenu()
        {
            List<Menu> listOfItems = _menuRepo.GetMenu();
            foreach (Menu items in listOfItems)
            {
                DisplayMenu(items);
            }
        }
        private void DisplayMenu(Menu items)
        {
            Console.Clear();
            Console.WriteLine($"Meal Number: {items.MealNumber}\n" +
                $"Meal Name: {items.MealName}\n" +
                $"Description: {items.Description}\n" +
                $"Price: {items.Price}\n" +
                $"Ingredients: {items.Ingredients}\n");
        }
        private void CreateNewItem()
        {
            Console.Clear();
            Console.Write("Enter a Meal Item: ");
            string mealName = Console.ReadLine();

            Console.Write("Enter a Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter a Meal Number: ");
            int mealNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the Price: ");

            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the Ingredients: ");
            string ingredients = Console.ReadLine();

            Menu newItems = new Menu(mealNumber, mealName, description, price, ingredients);

            _menuRepo.AddItemToMenu(newItems);
        }
        private void DeleteExistingItem()
        {
            Console.Clear();
            DisplayMenu();
            Console.WriteLine("Which item do you want to remove?");

            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _menuRepo.DeleteItemByMealNumber(input);
            if (wasDeleted)
            {
                Console.WriteLine("Item has been deleted");
            }

            else
            {
                Console.WriteLine("The item could not be deleted");
            }

        }
        private void SeedMenuItems()
        {
            Menu hamSandwich = new Menu(1, "Ham Sandwhich.", "Ham Pattie on a bun.", (decimal)3.00, "Ham Pattie, White Bun, American Cheese, Lettuce, Tomato, Mustard");
            Menu macAndCheese = new Menu(2, "Mac and Cheese.", "Plain old Mac and Cheese.", (decimal)2.00, "Noodles and Cheese");
            Menu chickenNoodleSoup = new Menu(3, "Chicken Noodle Soup.", "Homemade Chicken Soup.", (decimal)1.50, "Chicken Broth, Chicken, Assorted Veggies");

            _menuRepo.AddItemToMenu(hamSandwich);
            _menuRepo.AddItemToMenu(macAndCheese);
            _menuRepo.AddItemToMenu(chickenNoodleSoup);
        }

    }
}
