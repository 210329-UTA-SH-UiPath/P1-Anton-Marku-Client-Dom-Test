﻿using Microsoft.AspNetCore.Mvc;
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
    public class OrderPizzaController : Controller
    {
        PbApi _api = new();

        public async Task<IActionResult> Index()
        {
            List<OrderPizza> items = new List<OrderPizza>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/OrderPizza");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<OrderPizza>>(result);
            }
            return View(items);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderPizza item)
        {
            item.Id = 0;
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = _api.Initial();
            var response = await client.PostAsync("api/OrderPizza", data);
            var result = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            using var client = _api.Initial();
            client.BaseAddress = new Uri(_api.url + "api/OrderPizza" + id);
            var response = client.GetAsync("");
            response.Wait();
            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<OrderPizza>();
                readTask.Wait();

                var op = readTask.Result;
                return View(op);
            }
            else
                return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int? Id)
        {
            using var client = _api.Initial();
            client.BaseAddress = new Uri(_api.url + "api/OrderPizza/" + Id);
            var response = await client.DeleteAsync("");
            var result = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}
