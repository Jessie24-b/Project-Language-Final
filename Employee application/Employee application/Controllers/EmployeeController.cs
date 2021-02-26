using Employee_application.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;


namespace Employee_application.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            var employeeValid = GetEmployeeToAuthenticate(employee.EmployeeEmail, employee.EmployeePassword);
            if (employeeValid != null)
            {
                HttpContext.Session.SetString("employeeId", employeeValid.EmployeeId.ToString());
            }
            return RedirectToAction("Index", "Home");

        }

        public JsonResult GetEmployees()
        {

            IEnumerable<Employee> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/employee/");

                var responseTask = client.GetAsync("GetEmployees");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    employees = readTask.Result;
                }
                else
                {
                    employees = Enumerable.Empty<Employee>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(employees);
        }

        public JsonResult GetEmployeeById([FromBody] int id)
        {

            Employee employee = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44351/api/employee/");
                var responseTask = client.GetAsync("GetEmployee?id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    employee = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }
            return Json(employee);
        }

        public JsonResult InsertEmployee([FromBody] Employee employee)
        {
            Employee employeeToReturn = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/employee/");
                var data = JsonSerializer.Serialize<Employee>(employee);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync("PostEmployee", content);
                responseTask.Wait();

                var result = responseTask.Result;

                try
                {
                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    employeeToReturn = readTask.Result;
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }

            }
            return Json(employeeToReturn);
        }

        public JsonResult UpdateEmployeeById([FromBody] Employee employee)
        {
            int resultToReturn;
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("https://localhost:44351/api/employee/");
                var data = JsonSerializer.Serialize<Employee>(employee);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var responseTask = client.PutAsync("PutEmployee?id=" + employee.EmployeeId, content);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    resultToReturn = 1;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                    resultToReturn = -1;
                }
            }
            return Json(resultToReturn);
        }

        public Employee GetEmployeeToAuthenticate(string email, string password)
        {

            Employee employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/employee/");
                try
                {
                    var responseTask = client.GetAsync("GetEmployeeToAuthenticate?email=" + email + "&password=" + password);
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Employee>();
                        readTask.Wait();

                        employee = readTask.Result;
                    }
                }
                catch (AggregateException agg_ex)
                {
                    var ex = agg_ex.InnerExceptions[0];
                }

            }

            return employee;
        }

       


    }
}

