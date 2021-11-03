using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingClassLibrary
{
    public enum Type
    {
        Potential = 1, Current, Past
    }

    public class Customer 
    { 
    
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Type Type { get; set; }
        public string Email { get; set; }

        public Customer()
        {

        }

        public Customer (int customerId, string firstName, string lastName, Type type, string email)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            Email = email;
        }
    }
}
