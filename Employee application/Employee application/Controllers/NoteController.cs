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
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult InsertNote([FromBody] Note note)
        {
            Note noteToReturn = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/note/");
                var data = JsonSerializer.Serialize<Note>(note);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync("PostNote", content);
                responseTask.Wait();

                var result = responseTask.Result;

                try
                {
                    var readTask = result.Content.ReadAsAsync<Note>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    noteToReturn = readTask.Result;
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }

            }
            return Json(noteToReturn);
        }

        public JsonResult GetNoteById([FromBody] int id)
        {

            Note note = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44351/api/note/");
                var responseTask = client.GetAsync("GetNoteForIssue/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Note>();
                    readTask.Wait();
                    //leen los estudiantes provenientes de la API
                    note = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }
            return Json(note);
        }

        public JsonResult UpdateNoteById([FromBody] Note note)
        {
            int resultToReturn;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/note/");
                var data = JsonSerializer.Serialize<Note>(note);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var responseTask = client.PutAsync("PutNote/" + note.IssueId, content);
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
