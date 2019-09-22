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
        private const string myUrl = "http://localhost:50089/api/foods";
        private HttpClient client = new HttpClient();


        public GetterAndPoster()
        {
            client.BaseAddress = new Uri(myUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void ReadAllFood()
        {
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                Food[] foodApi = response.Content.ReadAsAsync<Food[]>().Result;
                for (int i = 0; i < foodApi.Length; i++)
                {
                Console.WriteLine($"{foodApi[i].ToString()}\n");
                }
            }
            else
            {
                Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
            }
        }

        public void AddFood()
        {
            Task t = Task.Run(() => PostInConsoleApp());
            t.Wait();
            Console.ReadKey();
        }

        private static async void PostInConsoleApp()
        {
            HttpResponseMessage response;
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string myFood = "{\"Name\": \"Somthing New\",\"Calories\": 10000,\"Ingridients\": \"Nothing\",\"Grade\": 20}";
            HttpContent httpContent = new StringContent(myFood, Encoding.UTF8, "application/json");
            response = await client.PostAsync(myUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.Write(response.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine($"{(int)response.StatusCode} {response.ReasonPhrase}");
            }
        }
    }
}
