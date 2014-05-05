using System;
using System.Collections.Generic;

namespace ElectronicHospital.com.Models
{
    public class DoctorAndUsers
    {
        public Doctor Doctor { get; set; }
        public List<User> Users { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}