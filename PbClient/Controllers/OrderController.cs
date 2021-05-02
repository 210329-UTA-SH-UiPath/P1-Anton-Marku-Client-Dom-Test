using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaBoxApi.Models;
using PizzaBoxClient.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PbClient.Controllers
{
    public class OrderController : Controller
    {
        PbApi _api = new();

        public async Task<IActionResult> Index()
        {
            List<Order> items = new List<Order>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Order");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Order>>(result);
            }
            items = items.Where(i => i.CustomerId == IFS.CustomerId).ToList();
            IFS.OrderIds.Clear();
            foreach(var item in items)
            {
                IFS.OrderIds.Add(item.Id);
            }
            return View(items);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order item)
        {
            item.CustomerId = IFS.CustomerId;
            item.OrderPizzas = new List<OrderPizza>();
            item.TotalPrice = 0;
            item.DateTime = DateTime.Now;
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = _api.Initial();
            var response = await client.PostAsync("api/Order", data);
            var result = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}
