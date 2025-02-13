using PublicKeyCryptography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicKeyCryptography.Services
{
    public class PatientService
    {
        private readonly List<Patient> patients = new List<Patient>();

        public void AddPatient(string name, int age, string email, string ssn, string history)
        {
            patients.Add(new Patient { Name = name, Age = age, Email = email, SSN = ssn, HistoryOfIllness = history });
        }

        public List<Patient> GetPatients() => patients;
    }
}
