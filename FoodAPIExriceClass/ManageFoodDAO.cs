using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAPIExriceClass
{
    public class ManageFoodDAO
    {
        public List<Food> GetAllFoods()
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                return foodEntites.Foods.ToList();
            }
        }

        public Food GetFoodById(int id)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                return foodEntites.Foods.FirstOrDefault(f => f.ID == id);
            }
        }

        public void AddFood(Food food)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                foodEntites.Foods.Add(food);
                foodEntites.SaveChanges();
            }

        }

        public Food UpdateFood(int id, Food food)
        {
            Food foodForUpdate = new Food();
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                foodForUpdate = foodEntites.Foods.FirstOrDefault(f => f.ID == id);
                foodForUpdate.Name = food.Name;
                foodForUpdate.Calories = food.Calories;
                foodForUpdate.Ingridients = food.Ingridients;
                foodForUpdate.Grade = food.Grade;
                foodEntites.SaveChanges();
            }
            return foodForUpdate;
        }

        public Food DeleteFood(int id)
        {
            Food foodForRemove;
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                foodForRemove = foodEntites.Foods.FirstOrDefault(f => f.ID == id);
                foodEntites.Foods.Remove(foodForRemove);
                foodEntites.SaveChanges();
            }
            return foodForRemove;
        }

        public List<Food> GetAllFoodsByName(string name)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper())).ToList();
            }
        }

        public List<Food> GetAllFoodsByMinCalories(int Calories)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                return foodEntites.Foods.Where(f => f.Calories > Calories).ToList();
            }
        }

        public List<Food> GetAllFoodsByFilter(string name, int mincal, int maxcal, int grade)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {

                if (name != "")
                {
                    if(mincal != 0)
                    {
                        if (maxcal != 0 && grade == 0) // Name, Mincal, Maxcal.
                            return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) && f.Calories > mincal && f.Calories < maxcal).ToList();
                        if (maxcal == 0 && grade != 0) // Name, Mincal, Grade.
                            return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) && f.Calories > mincal && f.Grade == grade).ToList();
                        if (maxcal == 0 && grade == 0) // Name, Mincal.
                            return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) && f.Calories > mincal).ToList();
                        if (maxcal != 0 && grade != 0) // All Filters.
                            return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) && f.Calories > mincal && f.Calories < maxcal && f.Grade == grade).ToList();

                    }
                    if (maxcal != 0)
                    {
                        if (grade != 0) // Name, Maxcal, Grade.
                            return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) && f.Calories < maxcal && f.Grade == grade).ToList();
                        if (grade == 0) // Name, Maxcal.
                            return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) && f.Calories < maxcal).ToList();

                    }
                    if (grade != 0) // Name, Grade.
                    {
                        return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) && f.Grade == grade).ToList();
                    }

                    // Only Name.
                        return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper())).ToList();
                }

                if (mincal != 0)
                {
                    if (maxcal != 0)
                    {
                        if (grade != 0) // Mincal, Maxcal, Grade.
                            return foodEntites.Foods.Where(f => f.Calories > mincal && f.Calories < maxcal && f.Grade == grade).ToList();

                        // Mincal, Maxcal.
                            return foodEntites.Foods.Where(f => f.Calories > mincal && f.Calories < maxcal).ToList();
                    }
                    if (grade != 0) // Mincal, Grade.
                    {
                        return foodEntites.Foods.Where(f => f.Calories > mincal && f.Grade == grade).ToList();
                    }

                    // Only Mincal.
                    return foodEntites.Foods.Where(f => f.Calories > mincal).ToList();
                }

                if (maxcal != 0)
                {
                    if (grade != 0) // Maxcal, Grade.
                        return foodEntites.Foods.Where(f => f.Calories < maxcal && f.Grade == grade).ToList();

                    // Only Maxcal.
                    return foodEntites.Foods.Where(f => f.Calories < maxcal).ToList();

                }

                if (grade != 0) // Only Grade.
                    return foodEntites.Foods.Where(f => f.Grade == grade).ToList();

                // All Filters.
                return foodEntites.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) && f.Calories > mincal && f.Calories < maxcal && f.Grade == grade).ToList();
            }
        }
    }
}
