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

        public bool AddMenuItemToDirectory(Menu menuItem)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(menuItem);
            bool wasAdded = _menuDirectory.Count > startingCount ? true : false;
            return wasAdded;
        }

        public List<Menu> GetAllMenuItems()
        {
            return _menuDirectory;
        }

        public bool DeleteMenuItem(Menu oldMenuItem)
        {
            bool deleteResult = _menuDirectory.Remove(oldMenuItem);
            return deleteResult;
        }
    }
}
