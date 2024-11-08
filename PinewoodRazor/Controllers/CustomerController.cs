using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PinewoodRazor.Models;
using System.Text;
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
        public async Task<IActionResult> IndexAsync()
        {
            List<Customer> CustomerList = new List<Customer>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Customer/GetCustomers").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                CustomerList = JsonConvert.DeserializeObject<List<Customer>>(data);
            }

            var UserList = await FetchFromApiAsync<List<User>>($"{baseAddress}/User/GetUsers");
            ViewBag.UsersList = UserList;


            return View(CustomerList);
        }


        [HttpGet]
        public async Task<IActionResult> EditCustomerAsync(int Id)
        {
            Customer CustomerDetails = new Customer();
            HttpResponseMessage responseCustomer = _httpClient.GetAsync(_httpClient.BaseAddress + "/Customer/GetCustomer/" + Id).Result;
            if (responseCustomer.IsSuccessStatusCode)
            {
                string data1 = responseCustomer.Content.ReadAsStringAsync().Result;
                CustomerDetails = JsonConvert.DeserializeObject<Customer>(data1);
            }

            var titleList = await FetchFromApiAsync<List<Title>>($"{baseAddress}/Title");
            var statusList = await FetchFromApiAsync<List<Status>>($"{baseAddress}/Status");
            var contactList = await FetchFromApiAsync<List<ContactViewModel>>($"{baseAddress}/Contact/GetContactsList/" + Id);
            var addressList = await FetchFromApiAsync<List<AddressViewModel>>($"{baseAddress}/Address/GetAddressesList/" + Id);
            var activityList = await FetchFromApiAsync<List<ActivityViewModel>>($"{baseAddress}/Activity/GetActivitiesList/" + Id);
            var UserList = await FetchFromApiAsync<List<User>>($"{baseAddress}/User/GetUsers");
            ViewBag.UsersList = UserList;

            // Prepare view model
            var viewModel = new CustomerViewModel
            {
                Customer = CustomerDetails,
                TitleList = titleList?.Select(c => new SelectListItem
                {
                    Value = c.TitleId.ToString(),
                    Text = c.TitleDescription
                }).ToList(),
                StatusList = statusList?.Select(c => new SelectListItem
                {
                    Value = c.StatusId.ToString(),
                    Text = c.StatusDescription
                }).ToList(),
                ContactList = contactList,
                AddressList = addressList,
                ActivityList = activityList
            };

            return View(viewModel);
        }


        private async Task<T> FetchFromApiAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
            return default;
        }


        [HttpPost]
        public async Task<IActionResult> SaveCustomer(Customer customer)
        {
            var baseAddress = _httpClient.BaseAddress.ToString().TrimEnd('/');
            customer.ModifiedDate = DateTime.UtcNow;

            // Update customer
            var updateResponse = await _httpClient.PostAsync($"{baseAddress}/Customer/UpdateCustomer/{customer.CustomerId}",
                new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json"));
            if (!updateResponse.IsSuccessStatusCode)
            {
                return StatusCode((int)updateResponse.StatusCode, "Failed to update customer.");
            }


            //After SAVE
            var CustomerDetails = await FetchFromApiAsync<Customer>($"{baseAddress}/Customer/GetCustomer/" + customer.CustomerId);

            var titleList = await FetchFromApiAsync<List<Title>>($"{baseAddress}/Title");
            var statusList = await FetchFromApiAsync<List<Status>>($"{baseAddress}/Status");
            var contactList = await FetchFromApiAsync<List<ContactViewModel>>($"{baseAddress}/Contact/GetContactsList/" + customer.CustomerId);
            var addressList = await FetchFromApiAsync<List<AddressViewModel>>($"{baseAddress}/Address/GetAddressesList/" + customer.CustomerId);
            var activityList = await FetchFromApiAsync<List<ActivityViewModel>>($"{baseAddress}/Activity/GetActivitiesList/" + customer.CustomerId);
            var UserList = await FetchFromApiAsync<List<User>>($"{baseAddress}/User/GetUsers");
            ViewBag.UsersList = UserList;

            // Prepare view model
            var viewModel = new CustomerViewModel
            {
                Customer = CustomerDetails,
                TitleList = titleList?.Select(c => new SelectListItem
                {
                    Value = c.TitleId.ToString(),
                    Text = c.TitleDescription
                }).ToList(),
                StatusList = statusList?.Select(c => new SelectListItem
                {
                    Value = c.StatusId.ToString(),
                    Text = c.StatusDescription
                }).ToList(),
                ContactList = contactList,
                AddressList = addressList,
                ActivityList = activityList
            };
            return View("EditCustomer", viewModel);
        }


        [HttpPost]
        public IActionResult UpdateUserSession(int selectedUserId)
        {
            // Store the selected user ID in session
            HttpContext.Session.SetInt32("SelectedUserId", selectedUserId);

            // Redirect to the previous page or another action as needed
            return Redirect(Request.Headers["Referer"].ToString());
        }


    }
}
