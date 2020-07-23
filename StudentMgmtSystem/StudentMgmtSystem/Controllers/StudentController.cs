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
        public async Task<ActionResult> Index(string submitButton, string DistrictIdSearch, string YearSearch, string StudentIdSearch, string SchoolYearSearch)
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
                    if (!string.IsNullOrEmpty(DistrictIdSearch))
                    {
                        studentViewModels.lstStudents = studentViewModels.lstStudents.Where(oh=>oh.DistrictId == Convert.ToInt32(DistrictIdSearch)).ToList();
                    }                 
                }
                HttpResponseMessage enrRes = await client.GetAsync("api/Enrollment/Get");
                if (enrRes.IsSuccessStatusCode)
                {
                    var StuResponse = enrRes.Content.ReadAsStringAsync().Result;
                    studentViewModels.lstEnrollment = JsonConvert.DeserializeObject<List<Enrollment>>(StuResponse);
                    if (!string.IsNullOrEmpty(YearSearch))
                    {
                        studentViewModels.lstEnrollment = studentViewModels.lstEnrollment.Where(oh => oh.SchoolYear == Convert.ToInt32(YearSearch)).ToList();
                    }
                }
                HttpResponseMessage serRes = await client.GetAsync("api/Service/Get");
                if (enrRes.IsSuccessStatusCode)
                {
                    var StuResponse = serRes.Content.ReadAsStringAsync().Result;
                    studentViewModels.lstService = JsonConvert.DeserializeObject<List<Service>>(StuResponse);
                    if (!string.IsNullOrEmpty(SchoolYearSearch) && !string.IsNullOrEmpty(StudentIdSearch))
                    {
                        studentViewModels.lstService = studentViewModels.lstService.Where(oh => oh.SchoolYear == Convert.ToInt32(SchoolYearSearch) && oh.StudentId == Convert.ToInt32(StudentIdSearch)).ToList();
                    }
                }
                return View(studentViewModels);
            }
        }
    }
}
