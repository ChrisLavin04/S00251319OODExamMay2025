using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace S00251319OODExamMay2025
{
    public class Patient
    {
        //Patient properties
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNumber { get; set; }

        //Patient can have many Appointments
        public List<Appointment> Appointments { get; set; }
    }

    //Declare Database context
    public class PatientData : DbContext
    {
        public PatientData() : base("OODExam_ChristopherLavin") { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}
