using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMgmtSystem.Models
{
    interface IStudentRepository
    {
        Task Add(StudentViewModel student);
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Enrollment>> GetEnrollment();
        Task<IEnumerable<Service>> GetService();
    }
}
