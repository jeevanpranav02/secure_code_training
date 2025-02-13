using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasscodeHandling.Services
{
    public class AuthService
    {
        private Dictionary<string, string> admins = new Dictionary<string, string>();
        private int failedAttempts = 0;
        private const int maxFailedAttempts = 3;

        public bool RegisterAdmin(string username, string passcode)
        {
            if (admins.ContainsKey(username)) return false;
            admins[username] = BCrypt.Net.BCrypt.HashPassword(passcode);
            return true;
        }

        public bool LoginAdmin(string username, string passcode)
        {
            if (failedAttempts >= maxFailedAttempts)
            {
                Console.WriteLine("\nToo many failed attempts. Try again later.\n");
                return false;
            }

            if (admins.ContainsKey(username) && BCrypt.Net.BCrypt.Verify(passcode, admins[username]))
            {
                Console.WriteLine("\nLogin successful! Welcome, " + username + "!\n");
                failedAttempts = 0;
                return true;
            }
            else
            {
                failedAttempts++;
                Console.WriteLine($"\nInvalid credentials. Attempts left: {maxFailedAttempts - failedAttempts}\n");
                return false;
            }
        }
    }}
