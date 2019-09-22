using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodExrice_ConsoleApp
{
    public class Foods
    {
        public Food Food { get; set; }
    }
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Calories { get; set; }
        public string Ingridients { get; set; }
        public Nullable<int> Grade { get; set; }

        public override string ToString()
        {
            return $"Food Id: {ID}. Name: {Name}. Calories: {Calories}. Ingridients: {Ingridients}. Grade: {Grade}.";
        }
    }
}
