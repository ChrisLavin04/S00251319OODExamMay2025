using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S00251319OODExamMay2025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Patient> Patients { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Patients = new ObservableCollection<Patient>();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new PatientData())
            {
                foreach (var patient in db.Patients.ToList())
                {
                    // Add each patient to the ListBox
                    LBXPatients.Items.Add($"{patient.Surname}, {patient.FirstName} - {patient.ContactNumber}");
                }
            }
        }

        private void BTNAddPatient_Click(object sender, RoutedEventArgs e)
        {
            string patientFirstName = TBXFirstName.Text;
            string patientSurname = TBXSurname.Text;
            string patientContactNumber = TBXPhoneNumber.Text;
            DateTime patientDOB = (DateTime)DPKDOB.SelectedDate;

            using (var db = new PatientData())
            {
                // Create a new patient object
                Patient newPatient = new Patient()
                {
                    FirstName = patientFirstName,
                    Surname = patientSurname,
                    ContactNumber = patientContactNumber,
                    DOB = patientDOB
                };
                // Add the new patient to the database
                db.Patients.Add(newPatient);
                db.SaveChanges();
                // Add the new patient to the ListBox
                LBXPatients.Items.Add($"{newPatient.Surname}, {newPatient.FirstName} - {newPatient.ContactNumber}");
                MessageBox.Show("Patient added successfully.");
            }
        }

        private void LBXPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPatient = (string)LBXPatients.SelectedItem;
            if (selectedPatient != null)
            {
                using (var db = new PatientData())
                {
                    if (db.Appointments.Count() == 0)
                    {
                        TBLKNoAppointmentsFound.Text = "No appointments found.";
                    }
                    else
                    {
                        TBLKNoAppointmentsFound.Text = string.Empty;
                    }
                    foreach (var appointment in db.Appointments.ToList())
                    {
                        // Get the selected patient's ID
                        int patientId = db.Patients.FirstOrDefault(p => $"{p.Surname}, {p.FirstName} - {p.ContactNumber}" == selectedPatient).PatientId;
                        // Check if the appointment belongs to the selected patient
                        if (appointment.PatientId == patientId)
                        {
                            // Add the appointment to the ListBox
                            LBXAppointments.Items.Add($"Appointment ID: {appointment.AppointmentId}, Time: {appointment.AppointmentTime}, Notes: {appointment.AppointmentNotes}");
                        }
                    }
                }
            }
            else
            {
                LBXAppointments.Items.Clear();
            }
        }

        private void BTNAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            var Appointmentwindow = new AppointmentDetails();
            Appointmentwindow.Show();
        }
    }
}
