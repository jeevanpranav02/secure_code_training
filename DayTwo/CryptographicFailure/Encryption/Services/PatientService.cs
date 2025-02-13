using Encryption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Services
{
    class PatientService
    {
        private List<Patient> patients = new List<Patient>();
        private byte[] encryptionKey;

        public PatientService()
        {
            encryptionKey = EncryptionService.GenerateKey();
        }

        public void AddPatient(string name, int age, string email, string ssn, string history)
        {
            string plaintextData = $"{name},{age},{email},{ssn},{history}";
            byte[] encryptedData = EncryptionService.Encrypt(plaintextData, encryptionKey);

            patients.Add(new Patient
            {
                Name = name,
                Age = age,
                Email = email,
                SSN = ssn,
                HistoryOfIllness = history,
                EncryptedData = encryptedData
            });
        }

        public void ViewPatients()
        {
            Console.WriteLine("\nStored Encrypted Patient Records:");
            foreach (var patient in patients)
            {
                foreach(var data in patient.EncryptedData)
                {
                    Console.Write(data);
                }
                //string decryptedData = EncryptionService.Decrypt(patient.EncryptedData, encryptionKey);
                //Console.WriteLine(decryptedData);
            }
        }
    }
}
