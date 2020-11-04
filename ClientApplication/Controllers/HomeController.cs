using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClientApplication.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace ClientApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Getting the token a Validating the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(Users user)
        {
            string token = GetToken("https://localhost:44385/api/Token", user);

            if (token != null)
            {
                return RedirectToAction("Dashboard", "Home", new { name = token });
            }
            else
            {
                ViewBag.invalid = "UserId or Password invalid";
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            Users obj = new Users { Email = "admin", Password = "admin" };
            using (HttpClient client = new HttpClient())
            {

                var token = GetToken("https://localhost:44385/api/Token", obj);
                client.BaseAddress = new Uri("https://localhost:44302/api/");
                // MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                //client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return View();
            }
        }
        static string GetToken(string url, Users user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
