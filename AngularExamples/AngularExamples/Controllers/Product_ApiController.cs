using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularExamples.Controllers
{
    public class Product_ApiController : ApiController
    {
        public static int PgaeLoadFlag = 1;
        public static List<Product2> products2 = new List<Product2>();
        public static int ProductID = 4;
        public Product_ApiController()
        {
            if (PgaeLoadFlag == 1) //use this only for first time page load
            {
                //Three product added to display the data
                products2.Add(new Product2 { ID = 1, Name = "bus", Category = "Toy", Price = 200.12M });
                products2.Add(new Product2 { ID = 2, Name = "Car", Category = "Toy", Price = 300 });
                products2.Add(new Product2 { ID = 3, Name = "robot", Category = "Toy", Price = 3000 });
                PgaeLoadFlag++;
            }
        }
        // GET api/product
        public List<Product2> GetAllProducts() //get method
        {
            //Instedd of static variable you can use database resource to get the data and return to API
            return products2.ToList(); //return all the product list data
        }
        public void ProductAdd(Product2 product) //post method
        {
            product.ID = ProductID;
            products2.Add(product); //add the post product data to the product list
            ProductID++;
            //instead of adding product data to the static product list you can save data to the database.
        }
        // GET: api/Product_Api
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product_Api/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product_Api
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product_Api/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product_Api/5
        public void Delete(int id)
        {
        }
        public class Product2
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
        }
    }
}
