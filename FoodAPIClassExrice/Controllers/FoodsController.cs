using FoodAPIExriceClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodAPIClassExrice.Controllers
{
    public class FoodsController : ApiController
    {
        public ManageFoodDAO mf = new ManageFoodDAO();
        public HttpResponseMessage Get()
        {
            List<Food> foods =  mf.GetAllFoods();
            HttpResponseMessage msg =  Request.CreateResponse(HttpStatusCode.OK, foods);
            return msg;
        }
        public HttpResponseMessage Get(int id)
        {
            Food food = mf.GetFoodById(id);
            return Request.CreateResponse(HttpStatusCode.OK, food);
        }

        public HttpResponseMessage Post([FromBody]Food value)
        {
            mf.AddFood(value);
            return Request.CreateResponse(HttpStatusCode.Created, value);
        }

        public HttpResponseMessage Put(int id, [FromBody]Food value)
        {
            Food food = mf.UpdateFood(id, value);
            return Request.CreateResponse(HttpStatusCode.Accepted, food);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Food food = mf.DeleteFood(id);
            return Request.CreateResponse(HttpStatusCode.OK, food);
        }

        [Route("api/foods/byname/{name}")]
        [HttpGet]
        public HttpResponseMessage GetByName(string name)
        {
            List<Food> foods = mf.GetAllFoodsByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }

        [Route("api/foods/bymincalor/{mincalories}")]
        [HttpGet]
        public HttpResponseMessage GetByMinCalories(int mincalories)
        {
            List<Food> foods = mf.GetAllFoodsByMinCalories(mincalories);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }

        [Route("api/foods/search")]
        [HttpGet]
        public HttpResponseMessage GetByFilter(string name = "", int mincal = 0, int maxcal = 0, int grade = 0)
        {
            List<Food> foods = mf.GetAllFoodsByFilter(name, mincal, maxcal, grade);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }
    }
}
