using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("HospitalConnection")
        {
            Database.SetInitializer<HospitalContext>(new CreateDatabaseIfNotExists<HospitalContext>());
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
    }
}