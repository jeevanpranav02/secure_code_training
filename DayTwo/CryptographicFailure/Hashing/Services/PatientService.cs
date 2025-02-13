using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasscodeHandling.Services
{
    public class PatientService
    {
        private Dictionary<string, string> patients = new Dictionary<string, string>();

        public void AddPatient(string id, string name)
        {
            patients[id] = name;
            Console.WriteLine("\nPatient added successfully!\n");
        }

        public void ViewPatients()
        {
            Console.WriteLine("\nPatient List:");
            if (patients.Count == 0)
            {
                Console.WriteLine("(No patients found.)\n");
                return;
            }
            foreach (var entry in patients)
            {
                Console.WriteLine($"ID: {entry.Key} | Name: {entry.Value}");
            }
            Console.WriteLine();
        }
    }
}
