using _05_GreetingClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_GreetingUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private CustomerRepository _customerRepository;
        private Customer _customer1;
        private Customer _customer2; 

        [TestInitialize]
        public void Arrange()
        {
            _customerRepository = new CustomerRepository();
            _customer1 = new Customer(1, "Darin", "Redden", _05_GreetingClassLibrary.Type.Current, "Email Test");
            _customer2 = new Customer(2, "Annie", "Redden", _05_GreetingClassLibrary.Type.Past, "Email Test 2");
        }

        [TestMethod]
        public void AddCustomerToDatabase_Test() 
        {
            bool wasAdded = _customerRepository.AddCustomerToDatabase(_customer2);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod] 
        public void GetAllCustomers_Test()
        {
            var _customer3 = new Customer(3, "DJ", "Redden", _05_GreetingClassLibrary.Type.Potential, "Email Test 3");
            _customerRepository.AddCustomerToDatabase(_customer3);
            var customerList = _customerRepository.GetAllCustomers();
            bool wasAdded = customerList.ContainsKey(3);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod] 
        public void UpdateCustomer_Test()
        {
            var _customer6 = new Customer(6, "TY", "Hilton", _05_GreetingClassLibrary.Type.Potential, "Test Email 6");
            var _customer7 = new Customer(7, "Peyton", "Manning", _05_GreetingClassLibrary.Type.Past, "Test Email 7");
            bool wasFound = _customerRepository.UpdateCustomer(_customer6.CustomerID, _customer7);
            Assert.IsFalse(wasFound);
        }

        [TestMethod] 
        public void DeleteExistingCustomer_Test()
        {
            var _customer4 = new Customer(4, "John", "Cena", _05_GreetingClassLibrary.Type.Past, "Email test");
            _customerRepository.AddCustomerToDatabase(_customer4);

            bool actual = _customerRepository.DeleteExistingCustomer(_customer4);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
