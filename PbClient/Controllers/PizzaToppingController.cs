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
    public class PizzaToppingController : Controller
    {
        PbApi _api = new();

        public async Task<IActionResult> Index()
        {
            List<PizzaTopping> items = new List<PizzaTopping>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/PizzaTopping");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<PizzaTopping>>(result);
            }
            return View(items);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PizzaTopping item)
        {
            item.Id = 0;
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = _api.Initial();
            var response = await client.PostAsync("api/PizzaTopping", data);
            var result = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}
