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
    public class PizzaController : Controller
    {
        PbApi _api = new();

        public async Task<IActionResult> Index()
        {
            List<Pizza> items = new List<Pizza>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Pizza/3");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Pizza>>(result);
            }
            return View(items);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pizza item)
        {
            item.Id = 0;
            item.Name = "Custom";
            item.Price = 0;
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = _api.Initial();
            var response = await client.PostAsync("api/Pizza", data);
            var result = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}
