using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PizzaBoxApi.Models;
using PizzaBoxClient.Controllers;
using PizzaBoxClient.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PbClient.Controllers
{
    public class CustomerController : Controller
    {

        PbApi _api = new PbApi();

        public async Task<IActionResult> Index()
        {
            List<Customer> items = new List<Customer>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Customer");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Customer>>(result);
            }
            return View(items);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer Customer)
        {
            Customer.Id = 0;
            var json = JsonConvert.SerializeObject(Customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = _api.Initial();
            var response = await client.PostAsync("api/customer", data);
            var result = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}
