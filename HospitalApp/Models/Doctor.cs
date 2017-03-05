using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}