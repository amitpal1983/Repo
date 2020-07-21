using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMgmtSystem.Models
{
    public class StudentViewModel
    {
        //public int DistrictId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public Nullable<System.DateTime> DateOfBirth { get; set; }
        //public string Ssn { get; set; }

        //public Nullable<int> SchoolYear { get; set; }
        //public Nullable<System.DateTime> StartDate { get; set; }
        //public Nullable<System.DateTime> EndDate { get; set; }

        public Student Students { get; set; }

        public Enrollment Enrollment { get; set; }

        public Service Service { get; set; }

        public List<Student> lstStudents { get; set; }

        public List<Enrollment> lstEnrollment { get; set; }

        public List<Service> lstService { get; set; }
    }
}