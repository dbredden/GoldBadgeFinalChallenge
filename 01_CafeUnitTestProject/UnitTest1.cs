using _01_CafeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_CafeUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepository _menuDirectory;
        private Menu _menuItem1;
        private Menu _menuItem2;

        [TestInitialize]
        public void Arrange() 
        {
            _menuDirectory = new MenuRepository();
            _menuItem1 = new Menu(1, "Burger", "World Famous Burger", "bun, meat, sauce", 5);
            _menuItem2 = new Menu(2, "Cheeseburger", "World Famouse Cheeseburger", "bun, meat, cheese, sauce", 6);
        }

        [TestMethod]
        public void AddMenuItemToDirectory_Test()
        {
            bool wasAdded = _menuDirectory.AddMenuItemToDirectory(_menuItem1);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetAllMenuItems_Test()
        {
            var _menuItem3 = new Menu(3, "Chicken Sandwich", "Our World Famous Chicken sandwich", "Chicken, buns, sauce", 5);
            _menuDirectory.AddMenuItemToDirectory(_menuItem3);
            var menuList = _menuDirectory.GetAllMenuItems();
            bool wasAdded = menuList.Contains(_menuItem3);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void DeleteMenuItems_Test()
        {
            var _menuItem3 = new Menu(3, "fries", "fries", "fries", 3);
            _menuDirectory.AddMenuItemToDirectory(_menuItem3);

            bool actual = _menuDirectory.DeleteMenuItem(_menuItem3);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
