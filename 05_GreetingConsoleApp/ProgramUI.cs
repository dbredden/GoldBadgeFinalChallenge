using _05_GreetingClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingConsoleApp
{
    public class ProgramUI
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepository();
        public void Run()
        {
            SeedCustomer();
            RunMenu();
        }

        public void RunMenu()
        {
            Console.WriteLine("Hello Welcome! View the menu options below.\n" +
                "1. Create\n" +
                "2. See List of Customers\n" +
                "3. Update Customer by the Customer ID\n" +
                "4. Delete Customer\n" +
                "5. See Customers in Alphabetical Order\n" +
                "6. Exit");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateNewCustomer();
                    Console.Clear();
                    RunMenu();
                    break;
                case "2":
                    ShowAllCustomers();
                    Console.Clear();
                    RunMenu();
                    break;
                case "3":
                    UpdateCustomer(); //NEED HELP
                    Console.Clear();
                    RunMenu();
                    break;
                case "4":
                    DeleteCustomer();
                    Console.Clear();
                    RunMenu();
                    break;
                case "5":
                    AlphabetizedCustomers();
                    Console.Clear();
                    RunMenu();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a number between 1 and 5\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
        private void CreateNewCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Time to create a new customer!\n" +
                "First - give the customer an ID number: ");
            customer.CustomerID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the customers first name?");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("What is the customers last name?");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("What is the customers type? Enter one of the following:\n" +
                "1. Current Customer \n" +
                "2. Potential Custoers \n" +
                "3. Past Customer");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    customer.Type = _05_GreetingClassLibrary.Type.Current;
                    break;
                case "2":
                    customer.Type = _05_GreetingClassLibrary.Type.Potential;
                    break;
                case "3":
                    customer.Type = _05_GreetingClassLibrary.Type.Past;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1-3");
                    break;
            }

            _customerRepository.CustomerEmail(customer);

            Console.WriteLine($"You have successfully added Customer ID: {customer.CustomerID} to the database.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void ShowAllCustomers()
        {
            Dictionary<int, Customer> listOfCustomers = _customerRepository.GetAllCustomers();

            foreach(KeyValuePair<int, Customer> kvp in listOfCustomers)
            {
                DisplayContent(kvp.Value);
                Console.WriteLine("----------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateCustomer()
        {
            // take input to find out who the customer is
            // go through my customers to find customer by ID input
            // update info

            Console.WriteLine("Enter the customer ID that belongs to the customer you wish to update?");
            int existingCustomerId = int.Parse(Console.ReadLine());
            Customer foundCustomer = _customerRepository.GetCustomerById(existingCustomerId);
            Customer newCustomer = new Customer();
            if (foundCustomer != null)
            {
                Console.WriteLine($"What would you like to update on {foundCustomer.CustomerID}?\n" +
                    $"1. Update Customer First Name\n" +
                    $"2. Update Customer Last Name\n" +
                    $"3. Update Customer Type\n" +
                    $"4. Go back to Main Menu.");
                string userInput = Console.ReadLine();
                switch (userInput) 
                {
                    case "1":
                        foundCustomer.FirstName = newCustomer.FirstName;
                        break;
                    case "2":
                        foundCustomer.LastName = newCustomer.LastName;
                        break;
                    case "3":
                        foundCustomer.Type = newCustomer.Type;
                        break;
                    case "4":
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("please enter a number between 1-4");
                        Console.ReadKey();
                        break;
                }
                //set things equal to a new variable named FoundCustomer
                //switch case for what the user wants to edit
                // found customer 1st 
            }
            else
            {
                Console.WriteLine("There is no customer with that Customer ID");
            }
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("Which customer do you wish to delete?");
            Dictionary<int, Customer > customerList = _customerRepository.GetAllCustomers();
            int count = 0;
            foreach(KeyValuePair<int, Customer> kvp in customerList)
            {
                count++;
                Console.WriteLine($"{count}.{kvp.Value.CustomerID}");
            }

            int targetCustomerId = int.Parse(Console.ReadLine());
            int targetIndex = targetCustomerId - 1;
            if (targetIndex >= 0 && targetIndex < customerList.Count)
            {
                Customer desiredCustomer = customerList[targetIndex];
                if (_customerRepository.DeleteExistingCustomer(desiredCustomer))
                {
                    Console.WriteLine($"{desiredCustomer.CustomerID} successfully removed.");
                }
                else
                {
                    Console.WriteLine("Customer was not able to be removed.");
                }
            }
            else
            {
                Console.WriteLine("No Customer has that Customer ID");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AlphabetizedCustomers()
        {
            Dictionary<int, Customer> listOfCustomers = _customerRepository.GetAllCustomers();

            foreach (KeyValuePair<int, Customer> kvp in listOfCustomers.OrderBy(key => key.Value.LastName))
            {
                DisplayContent(kvp.Value);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplayContent(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerID}");
            Console.WriteLine($"{customer.FirstName}");
            Console.WriteLine($"{customer.LastName}");
            Console.WriteLine($"{customer.Type}");
        }

        private void SeedCustomer()
        {
            Customer customerOne = new Customer(1, "Danny", "Redden", _05_GreetingClassLibrary.Type.Current, "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            Customer customerTwo = new Customer(2, "Noah", "Anderson", _05_GreetingClassLibrary.Type.Potential, "We currently have the lowest rates on Helicopter Insurance!");
            Customer customerThree = new Customer(3, "Kaleb", "Miller", _05_GreetingClassLibrary.Type.Past, "It's been a long time since we've heard from you, we want you back");
        }
    }
}
