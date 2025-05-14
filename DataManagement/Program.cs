using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S00251319OODExamMay2025;

namespace DataManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatientData db = new PatientData();


            //Add patients to database
            using (db)
            {
                Patient p1 = new Patient()
                {
                    FirstName = "John",
                    Surname = "Smith",
                    DOB = new DateTime(2000, 01, 31),
                    ContactNumber = "086 123 4567"
                };

                Patient p2 = new Patient()
                {
                    FirstName = "Mary",
                    Surname = "Jones",
                    DOB = new DateTime(1980, 06, 15),
                    ContactNumber = "087 323 2585"
                };

                Patient p3 = new Patient()
                {
                    FirstName = "Jim",
                    Surname = "Ryan",
                    DOB = new DateTime(2005, 03, 10),
                    ContactNumber = "086 568 7896"
                };

                db.Patients.Add(p1);
                db.Patients.Add(p2);
                db.Patients.Add(p3);

                Console.WriteLine("Added Patients to Database");
                db.SaveChanges();
                Console.WriteLine("Changes Saved");
            }
        }
    }
}
