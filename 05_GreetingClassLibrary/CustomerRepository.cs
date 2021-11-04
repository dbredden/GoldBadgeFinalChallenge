using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingClassLibrary
{
    public class CustomerRepository
    {
        private readonly Dictionary<int, Customer> _customerDatabase = new Dictionary<int, Customer>();

        public bool AddCustomerToDatabase (Customer newCustomer)
        {
            int startingCount = _customerDatabase.Count;
            _customerDatabase.Add(newCustomer.CustomerID, newCustomer);
            bool wasAdded = _customerDatabase.Count > startingCount ? true : false;
            return wasAdded;
        }

        public Dictionary<int, Customer> GetAllCustomers()
        {
            return _customerDatabase;
        }

        public Customer GetCustomerById(int customerId)
        {
            foreach(KeyValuePair<int, Customer>  kvp in _customerDatabase)
            {
                if (customerId == kvp.Key)
                    return kvp.Value;
            }
            return null;
        }

        public bool UpdateCustomer(int originalCustomerId, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerById(originalCustomerId); 

            if (oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.Type = newCustomer.Type;
                oldCustomer.Email = newCustomer.Email;
                oldCustomer.CustomerID = newCustomer.CustomerID;
            }
            return false;
        }

        public bool DeleteExistingCustomer(Customer existingCustomer)
        {
            bool deleteResult = _customerDatabase.Remove(existingCustomer.CustomerID);
            return deleteResult;
        }

        public void CustomerEmail(Customer customer)
        {
            switch(customer.Type)
            {
                case Type.Past:
                    customer.Email = "It's been a long time since we've heard from you, we want you back";
                    break;
                case Type.Current:
                    customer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case Type.Potential:
                    customer.Email = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
            }
        }
    }
}
