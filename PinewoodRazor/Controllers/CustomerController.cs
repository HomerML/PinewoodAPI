using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PinewoodRazor.Models;
using System.Text.Json.Serialization;

namespace PinewoodRazor.Controllers
{
    public class CustomerController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7026/api");

        private readonly HttpClient _httpClient;

        public CustomerController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> CustomerList = new List<Customer>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Customer/GetCustomers").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                CustomerList = JsonConvert.DeserializeObject<List<Customer>>(data);
            }
            return View(CustomerList);
        }

    }
}
