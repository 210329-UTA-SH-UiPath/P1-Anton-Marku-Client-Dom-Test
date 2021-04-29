using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBoxClient.Helper
{
    public class PbApi
    {
        public string url = "http://localhost:54713/";
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54713/");
            return client;
        }
    }
}
