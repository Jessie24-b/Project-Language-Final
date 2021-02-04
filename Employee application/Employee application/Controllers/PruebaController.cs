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
    public class PruebaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public JsonResult PostEmployee([FromBody] Employee employee)
        {
            int resultDataBase;

            using (var client = new HttpClient())
            {
                string url = "https://localhost:44346/api/Employee";
                var data = JsonSerializer.Serialize<Employee>(employee);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync(url, content);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {

                    resultDataBase = 1;
                }
                else
                {
                    resultDataBase = -1;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }

                return Json(resultDataBase);


            }


        }

    }
}
