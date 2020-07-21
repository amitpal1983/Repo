using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using StudentMgmtSystem.Models;
using Newtonsoft.Json;

namespace StudentMgmtSystem.Controllers
{
    public class StudentController : Controller
    {
        string Baseurl = "http://localhost:5482/";
        public async Task<ActionResult> Index()
        {
            StudentViewModel studentViewModels = new StudentViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage stuRes = await client.GetAsync("api/Students/Get");
                if (stuRes.IsSuccessStatusCode)
                {
                    var StuResponse = stuRes.Content.ReadAsStringAsync().Result;
                    studentViewModels.lstStudents = JsonConvert.DeserializeObject<List<Student>>(StuResponse);
                }
                HttpResponseMessage enrRes = await client.GetAsync("api/Enrollment/Get");
                if (enrRes.IsSuccessStatusCode)
                {
                    var StuResponse = enrRes.Content.ReadAsStringAsync().Result;
                    studentViewModels.lstEnrollment = JsonConvert.DeserializeObject<List<Enrollment>>(StuResponse);
                }
                HttpResponseMessage serRes = await client.GetAsync("api/Service/Get");
                if (enrRes.IsSuccessStatusCode)
                {
                    var StuResponse = serRes.Content.ReadAsStringAsync().Result;
                    studentViewModels.lstService = JsonConvert.DeserializeObject<List<Service>>(StuResponse);
                }
                return View(studentViewModels);
            }



            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(apiBaseAddress);

            //    var resStudent = client.GetAsync("Students/Get");

            //    if (resStudent != null)
            //    {
            //        var resEnrollment = client.GetAsync("Enrollment/get");
            //    }
            //    //else
            //    //{
            //    //    employees = Enumerable.Empty<Employee>();
            //    //    ModelState.AddModelError(string.Empty, "Server error try after some time.");
            //    //}
            //}

            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Address,Gender,Company,Designation")] StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    var response = await client.PostAsJsonAsync("Students/Create", studentViewModel);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
            }
            return View(studentViewModel);
        }
    }
}