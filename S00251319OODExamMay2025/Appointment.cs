using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S00251319OODExamMay2025
{
    public class Appointment
    {
        //Appointment properties
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string AppointmentNotes { get; set; }

        public int PatientId { get; set; }
    }
}
