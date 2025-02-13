using Encryption.Services;

namespace Encryption
{
    class Program
    {
        static void Main()
        {
            AdminService adminService = new AdminService();
            PatientService patientService = new PatientService();

            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            if (!adminService.Authenticate(username, password))
            {
                Console.WriteLine("Access Denied! Invalid Credentials.");
                return;
            }

            Console.WriteLine("Admin Authentication Successful!");

            while (true)
            {
                Console.WriteLine("\n1. Add Patient\n2. View Patients\n3. Exit");
                Console.Write("Choose an option: ");
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
                        break;
                    case "2":
                        patientService.ViewPatients();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }

}