using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentMgmtSystem.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MagicSoftTestEntities db = new MagicSoftTestEntities();

        public async Task Add(StudentViewModel studentViewModel)
        {
            Student student = new Student();
            student.FirstName = studentViewModel.Students.FirstName;
            student.LastName = studentViewModel.Students.LastName;
            student.DateOfBirth = studentViewModel.Students.DateOfBirth;
            student.Ssn = studentViewModel.Students.Ssn;
            db.Students.Add(student);
            await db.SaveChangesAsync();

            Enrollment enrollment = new Enrollment();
            enrollment.StudentId = studentViewModel.Students.DistrictId;
            enrollment.SchoolYear = studentViewModel.Enrollment.SchoolYear;
            enrollment.StartDate = studentViewModel.Enrollment.StartDate;
            enrollment.EndDate = studentViewModel.Enrollment.EndDate;
            db.Enrollments.Add(enrollment);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                var student = db.Students.ToList();
                return student.AsQueryable();
            }
            catch
            {
                throw;   
            }
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollment()
        {
            try
            {
                var enrollments = db.Enrollments.ToList();
                return enrollments.AsQueryable();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Service>> GetService()
        {
            try
            {
                var services = db.Services.ToList();
                return services.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
    }
}