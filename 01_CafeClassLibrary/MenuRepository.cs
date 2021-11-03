using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeClassLibrary
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>(); 

        // CREATE

        public bool AddMenuItemToDirectory(Menu menuItem)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(menuItem);
            bool wasAdded = _menuDirectory.Count > startingCount ? true : false;
            return wasAdded;
        }

        // READ
        public List<Menu> GetAllMenuItems()
        {
            return _menuDirectory;
        }



        // DELETE
        public bool DeleteMenuItem(Menu oldMenuItem)
        {
            bool deleteResult = _menuDirectory.Remove(oldMenuItem);
            return deleteResult;
        }
    }
}
