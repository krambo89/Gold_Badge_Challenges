using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenges
{
    public class MenuRepository
    {
        private readonly List<Menu> _menuItems = new List<Menu>();

        public void AddItemToMenu(Menu items)
        {
            _menuItems.Add(items);
        }
        public List<Menu> GetMenu()
        {
            return _menuItems;
        } 
        public bool DeleteExistingItem(Menu item)
        {
            return _menuItems.Remove(item);
        }
        public bool DeleteItemByMealNumber(int mealNumber)
        {
             Menu targetNumber = GetItemByNumber(mealNumber);
            return DeleteExistingItem(targetNumber);
        }
        public Menu GetItemByNumber(int mealNumber)
        {
            foreach (Menu item in _menuItems)
            {
                if (item.MealNumber == mealNumber)
                { 
                    return item;
                }
            }
            return null;
        }
    }
}
