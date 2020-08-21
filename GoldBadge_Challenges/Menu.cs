using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenges
{
    public class Menu
    {
        public Menu() { }
        public Menu(int mealNumber, string mealName, string description, decimal price, string ingredients)
        {
            MealName = mealName;
            Description = description;
            MealNumber = mealNumber;
            Price = price;
            Ingredients = ingredients;
        }
        public string MealName { get; set; }
        public string Description { get; set; }
        public int MealNumber { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
    }

    



    
}
