using Employee_application.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employee_application.Controllers
{
    public class EmployeeServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployeeServicesByIdService([FromBody] int id)
        {

            IEnumerable<EmployeeService> employeeServices = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/EmployeeService/");

                var responseTask = client.GetAsync("GetEmployeeServiceByIdService/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EmployeeService>>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    employeeServices = readTask.Result;
                }
                else
                {
                    employeeServices = Enumerable.Empty<EmployeeService>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(employeeServices);
        }

        public JsonResult InsertEmployeeService([FromBody] EmployeeService employeeService)
        {
            EmployeeService employeeServiceToReturn = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/EmployeeService/");
                var data = JsonSerializer.Serialize<EmployeeService>(employeeService);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync("PostEmployeeService", content);
                responseTask.Wait();

                var result = responseTask.Result;

                try
                {
                    var readTask = result.Content.ReadAsAsync<EmployeeService>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    employeeServiceToReturn = readTask.Result;
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }

            }
            return Json(employeeServiceToReturn);
        }



    }
}
