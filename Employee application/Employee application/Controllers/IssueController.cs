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
    public class IssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetIssues()
        {

            IEnumerable<Issue> issues = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/issue/");

                var responseTask = client.GetAsync("getissues");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Issue>>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    issues = readTask.Result;
                }
                else
                {
                    issues = Enumerable.Empty<Issue>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(issues);
        }

        public JsonResult GetIssues2()
        {

            IEnumerable<Issue> issues = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:8080/api/issue/");

                var responseTask = client.GetAsync("issues");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Issue>>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    issues = readTask.Result;
                }
                else
                {
                    issues = Enumerable.Empty<Issue>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(issues);

        }
        public JsonResult GetIssueById([FromBody] int id)
        {

            Issue issue = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44351/api/issue/");
                var responseTask = client.GetAsync("GetIssue?id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Issue>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    issue = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }
            return Json(issue);
        }

        public JsonResult GetIssue2ById([FromBody] int id)
        {

            Issue issue = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44351/api/issue/");
                var responseTask = client.GetAsync("GetIssue?id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Issue>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    issue = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }
            return Json(issue);
        }

        public JsonResult UpdateIssueById([FromBody] Issue issue)
        {
            int resultToReturn;
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("https://localhost:44351/api/issue/");
                var data = JsonSerializer.Serialize<Issue>(issue);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var responseTask = client.PutAsync("PutIssue?id=" + issue.ReportId, content);
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


    }
}
