using StudentMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentMgmtSystem.Controllers
{
    public class StudentApiController : ApiController
    {
        private readonly IStudentRepository _studentRepository = new StudentRepository();

        [HttpGet]
        [Route("api/Students/Get")]
        public async Task<IEnumerable<Student>> Get()
        {
               return await _studentRepository.GetStudents();

            //IEnumerable<StudentViewModel> StudentVM = (IEnumerable<StudentViewModel>)_studentRepository.GetStudents()
            //               .Join(
            //               _studentRepository.GetEnrollment(),
            //               student => student.DistrictId,
            //               enroll => enroll.StudentId,
            //               (student, enroll) => new
            //               {
            //                   DistrictId = student.DistrictId,
            //                   FirstName = student.FirstName,
            //                   LastName = student.LastName,
            //                   DateOfBirth = student.DateOfBirth,
            //                   Ssn = student.Ssn,

            //                   SchoolYear = enroll.SchoolYear,
            //                   StartDate = enroll.StartDate,
            //                   EndDate = enroll.EndDate
            //               }).ToList();

            //return StudentVM;
        }

        [HttpGet]
        [Route("api/Enrollment/Get")]
        public async Task<IEnumerable<Enrollment>> GetEnrollment()
        {
            return await  _studentRepository.GetEnrollment();
        }

        [HttpGet]
        [Route("api/Service/Get")]
        public async Task<IEnumerable<Service>> GetService()
        {
            return await _studentRepository.GetService();
        }


    }
}
