using PublicKeyCryptography.Services;

namespace PublicKeyCryptography
{
    class Program
    {
        static void Main()
        {
            AdminService adminService = new AdminService();
            PatientService patientService = new PatientService();
            CryptoGraphicService cryptoService = new CryptoGraphicService();

            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (!adminService.Authenticate(username, password))
            {
                Console.WriteLine("Invalid credentials. Exiting...");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n1. Add Patient\n2. View Patients\n3. Send Patient Details\n4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter SSN: ");
                        string ssn = Console.ReadLine();
                        Console.Write("Enter History of Illness: ");
                        string history = Console.ReadLine();

                        patientService.AddPatient(name, age, email, ssn, history);
                        Console.WriteLine("Patient added successfully.");
                        break;

                    case "2":
                        foreach (var patient in patientService.GetPatients())
                        {
                            Console.WriteLine($"Name: {patient.Name}, Age: {patient.Age}, Email: {patient.Email}, SSN: {patient.SSN}, History: {patient.HistoryOfIllness}");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Patient Name to Encrypt Details: ");
                        string patientName = Console.ReadLine();
                        var selectedPatient = patientService.GetPatients().Find(p => p.Name == patientName);
                        cryptoService.GenerateKeys();

                        if (selectedPatient != null)
                        {
                            string patientData = $"{selectedPatient.Name},{selectedPatient.Age},{selectedPatient.Email},{selectedPatient.SSN},{selectedPatient.HistoryOfIllness}";
                            byte[] encryptedData = cryptoService.EncryptData(patientData);
                            File.WriteAllBytes("encrypted_patient_data.bin", encryptedData);
                            Console.WriteLine("Patient details encrypted and saved.");
                        }
                        else
                        {
                            Console.WriteLine("Patient not found.");
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}