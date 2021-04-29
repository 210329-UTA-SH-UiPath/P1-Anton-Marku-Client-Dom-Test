using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PbClient.Models;
using PizzaBoxApi.Models;
using PizzaBoxClient.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBoxClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        PbApi _api = new PbApi();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> ShowStores()
        {
            List<Store> items = new List<Store>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Store");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Store>>(result);
            }
            return View(items);
        }

        public async Task<IActionResult> ShowSizes()
        {
            List<Size> items = new List<Size>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Size");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Size>>(result);
            }
            return View(items);
        }

        public async Task<IActionResult> ShowCrusts()
        {
            List<Crust> items = new List<Crust>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Crust");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Crust>>(result);
            }
            return View(items);
        }

        public async Task<IActionResult> ShowToppings()
        {
            List<Topping> items = new List<Topping>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Topping");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Topping>>(result);
            }
            return View(items);
        }

        public async Task<IActionResult> ShowPizzaPresets()
        {
            List<Pizza> items = new List<Pizza>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Pizza");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Pizza>>(result);
            }
            return View(items);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
