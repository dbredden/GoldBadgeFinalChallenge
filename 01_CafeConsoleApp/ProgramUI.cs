using _01_CafeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeConsoleApp
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while(continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Menu Management system.\n" +
                    "Follow the directions below to make any changes.\n" +
                    "1. Add a Menu Item.\n" +
                    "2. Delete a Menu Item.\n" +
                    "3. See All Menu Items.\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateMenuItem();
                        Console.Clear();
                        RunMenu();
                        break;
                    case "2":
                        DeleteMenuItem();
                        Console.Clear();
                        RunMenu();
                        break;
                    case "3":
                        ShowAllMenuItems();
                        Console.Clear();
                        RunMenu();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Enter a number between 1 and 4");
                        Console.ReadKey();
                        break;
                }   
            }
        }
        private void CreateMenuItem()
        {
            Menu menuItem = new Menu();
            Console.WriteLine("TIme to add a new meal to our menu!\n" +
                "Let's get started!\n" +
                "Please enter the meal number: ");
            menuItem.MealNumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the meal name: ");
            menuItem.MealName = Console.ReadLine();

            Console.WriteLine("Please enter the meal description: ");
            menuItem.Description = Console.ReadLine();

            Console.WriteLine("Please enter the meal ingredients: ");
            menuItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter the price of the meal: ");
            string priceInput = Console.ReadLine();
            try
            {
                menuItem.Price = double.Parse(priceInput);
            }
            catch
            {
                Console.WriteLine("Sorry you need to enter a valid price!");
            }
            _menuRepo.AddMenuItemToDirectory(menuItem);
            Console.WriteLine($"{menuItem.MealName} was successfully created.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllMenuItems()
        {
            List<Menu> listOfMenuItems = _menuRepo.GetAllMenuItems();

            foreach(Menu menuItem in listOfMenuItems)
            {
                DisplayMenuItems(menuItem);
                Console.WriteLine("--------------------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DeleteMenuItem()
        {
            Console.WriteLine("Which meal would you like to remove? Enter the list number of the meal.");
            List<Menu> listOfMenuItems = _menuRepo.GetAllMenuItems();
            int count = 0;
            foreach(Menu menuItem in listOfMenuItems)
            {
                count++;
                Console.WriteLine($"{count}. {menuItem.MealName}");
            }

            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            if (targetIndex >= 0 && targetIndex < listOfMenuItems.Count)
            {
                Menu desiredMenuItem = listOfMenuItems[targetIndex];
                if (_menuRepo.DeleteMenuItem(desiredMenuItem))
                {
                    Console.WriteLine($"{desiredMenuItem.MealName} successfully removed.");
                }
                else
                {
                    Console.WriteLine("I'm sorry I can't remove that item.");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayMenuItems(Menu menuItem)
        {
            Console.WriteLine($"Meal Number: {menuItem.MealNumber}");
            Console.WriteLine($"Meal Name: {menuItem.MealName}");
            Console.WriteLine($"Meal Description: {menuItem.Description}");
            Console.WriteLine($"Meal Ingredients: {menuItem.Ingredients}");
            Console.WriteLine($"Price: {menuItem.Price}");
        }

        private void SeedMenu()
        {
            Menu menuItemOne = new Menu(1, "Cheeseburger", "Our original world-famous cheeseburger", "buns, beef, cheese, lettuce, tomato, pickles, mystery sauce", 5);
            Menu menuItemTwo = new Menu(2, "Hamburger", "Our original world-famous hamburger", "buns, beef, lettuce, tomato, pickles, mystery sauce", 4);
            Menu menuItemThree = new Menu(3, "Chicken Strips", "Our original world-famous chicken strips", "chicken, breading, side of mystery sauce", 6);

            _menuRepo.AddMenuItemToDirectory(menuItemOne);
            _menuRepo.AddMenuItemToDirectory(menuItemTwo);
            _menuRepo.AddMenuItemToDirectory(menuItemThree);
        }
    }
}
