using FoodAPIClassExrice.Controllers;
using FoodAPIExriceClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FoodExrice_ConsoleApp
{
    public class GetterAndPoster
    {
        private FoodsController foodsController = new FoodsController();
        //private const string foodsURL = "http://localhost:50089/api/foods";
        private HttpClient client = new HttpClient();

        public GetterAndPoster()
        {
            //client.BaseAddress = new Uri(foodsURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void ReadAllFood()
        {
            List<Food> foods = foodsController.mf.GetAllFoods();
            //Food result = response.Content.ReadAsAsync<Food>().Result;
            //Console.WriteLine(foods.to);
            foreach (Food food in foods)
            {
                Console.WriteLine(food.ToString());
            }
            Console.WriteLine("\n\n");
        }

        public void AddFood()
        {
            foodsController.mf.AddFood(new Food { Name = Console.ReadLine(), Calories = Convert.ToInt32(Console.ReadLine()), Ingridients = Console.ReadLine(), Grade = Convert.ToInt32(Console.ReadLine()) });
            ReadAllFood();
        }
    }
}
