using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(
            User employeeData)
        {
            bool IsEmployeeExist = false;
            User user = new User();
            if (ModelState.IsValid)
            {
                user.FirstName = employeeData.FirstName;
                user.LastName = employeeData.LastName;
                string startupPath = Environment.CurrentDirectory;
                string fileName = "User.json";
                string filePath = Path.Combine(Environment.CurrentDirectory, @"Json\", fileName);
                //var filePath = @"C:\Users\pmahamuni\source\repos\WebApplication3\WebApplication3\Json\User.json";
                // Read existing json data
                var jsonData = System.IO.File.ReadAllText(filePath);
                // De-serialize to object or create new list
                var employeeList = JsonConvert.DeserializeObject<List<User>>(jsonData)
                                   ?? new List<User>();
                // Add any new employees
                employeeList.Add(user);

                // Update json data string
                jsonData = JsonConvert.SerializeObject(employeeList);
                System.IO.File.WriteAllText(filePath, jsonData);
                return RedirectToAction(nameof(Index));
            }

            return View(employeeData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
