using System;
using System.IO;
using System.Collections.Generic;
using BCrypt.Net;
using SecurePasscodeHandling.Services;


class Program
{
    static AuthService authService = new AuthService();
    static PatientService patientService = new PatientService();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== HOSPITAL MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Register Admin");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RegisterAdmin();
                    break;
                case "2":
                    if (LoginAdmin())
                        ManagePatients();
                    break;
                case "3":
                    Console.WriteLine("\nGoodbye!");
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Try again.\n");
                    break;
            }
        }
    }

    static void RegisterAdmin()
    {
        Console.Write("\nEnter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter passcode: ");
        string passcode = Console.ReadLine();
        if (authService.RegisterAdmin(username, passcode))
            Console.WriteLine("\nAdmin registered successfully!\n");
        else
            Console.WriteLine("\nUsername already exists!\n");
    }

    static bool LoginAdmin()
    {
        Console.Write("\nEnter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter passcode: ");
        string passcode = Console.ReadLine();
        return authService.LoginAdmin(username, passcode);
    }

    static void ManagePatients()
    {
        while (true)
        {
            Console.WriteLine("\n===== PATIENT MANAGEMENT =====");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. View Patients");
            Console.WriteLine("3. Logout");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddPatient();
                    break;
                case "2":
                    patientService.ViewPatients();
                    break;
                case "3":
                    Console.WriteLine("\nLogged out successfully!\n");
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Try again.\n");
                    break;
            }
        }
    }

    static void AddPatient()
    {
        Console.Write("\nEnter Patient ID: ");
        string id = Console.ReadLine();
        Console.Write("Enter Patient Name: ");
        string name = Console.ReadLine();
        patientService.AddPatient(id, name);
    }
}

