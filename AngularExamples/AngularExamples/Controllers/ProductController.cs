using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace AngularExamples.Controllers
{
    public class ProductController : Controller
    {
        public static int PgaeLoadFlag = 1;
        public static List<Product> products = new List<Product>();
        public static int ProductID = 4;
        // GET: Product
        public ProductController()
        {
            if (PgaeLoadFlag == 1) //use this only for first time page load
            {
                //Three product added to display the data
                products.Add(new Product { ID = 1, Name = "bus", Category = "Toy", Price = 200.12M });
                products.Add(new Product { ID = 2, Name = "Car", Category = "Toy", Price = 300 });
                products.Add(new Product { ID = 3, Name = "robot", Category = "Toy", Price = 3000 });
                PgaeLoadFlag++;
            }
        }
        // GET api/product
        public List<Product> GetAllProducts() //get method
        {
            //Instedd of static variable you can use database resource to get the data and return to API
            return products.ToList(); //return all the product list data
        }
        public void ProductAdd(Product product) //post method
        {
            product.ID = ProductID;
            products.Add(product); //add the post product data to the product list
            ProductID++;
            //instead of adding product data to the static product list you can save data to the database.
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
