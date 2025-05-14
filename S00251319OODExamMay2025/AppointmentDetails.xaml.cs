using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace S00251319OODExamMay2025
{
    /// <summary>
    /// Interaction logic for AppointmentDetails.xaml
    /// </summary>
    public partial class AppointmentDetails : Window
    {
        public AppointmentDetails()
        {
            InitializeComponent();
        }

        private void BTNAddAppointment_Click(object sender, RoutedEventArgs e)
        {
                    {
            
            DateTime AppointmentTime = (DateTime)DPKAppointmentTime.SelectedTime;
            string AppointmentNotes = TBXAppointmentNotes.Text;
            //var selectedPatient = mainWindow.LBXPatients.SelectedItem;
            //int patientID = ((Patient)selectedPatient).PatientId;
            using (var db = new PatientData())
            {
                // Create a new appointment object
                Appointment newAppointment = new Appointment()
                {
                    AppointmentTime = AppointmentTime,
                    AppointmentNotes = AppointmentNotes,
                    //PatientId = patientID
                };
                // Add the new appointment to the database
                db.Appointments.Add(newAppointment);
                db.SaveChanges();
                MessageBox.Show("Appointment added successfully.");
            }
        }
        }
    }
}
