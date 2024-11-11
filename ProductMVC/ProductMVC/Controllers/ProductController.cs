using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductMVC.Models;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _client;

        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44324/api/");
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductEntity> products = new List<ProductEntity>();

            try
            {
                HttpResponseMessage response = _client.GetAsync("Product/GetAllProducts").Result;
                if (response.IsSuccessStatusCode)
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<ProductEntity>>(data);
                }
                else { return RedirectToAction("NotAuthorized"); }
            }
            catch (HttpRequestException ex)
            {

                Console.WriteLine($"Error accessing API: {ex.Message}");

                throw;
            }

            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto product)
        {
            try
            {

                String data = JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync("Product/AddProduct", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductEntity product = new ProductEntity();
            HttpResponseMessage response = _client.GetAsync("Product/GetProductById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductEntity>(data);
            }

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductEntity product)
        {
            try
            {

                String data = JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync("Product/UpdateProduct", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                return View();
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductEntity product = new ProductEntity();
            HttpResponseMessage response = _client.GetAsync("Product/GetProductById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductEntity>(data);
            }

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync("Product/DeleteProduct/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            try
            {

            }
            catch (Exception)
            {

                return View();
            }
            return View();

        }
        [HttpGet]
        public IActionResult NotAuthorized() { return View(); }



    }
}
