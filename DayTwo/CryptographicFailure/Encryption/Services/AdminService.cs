using Encryption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Services
{
    public class AdminService
{
    private List<Admin> admins = new List<Admin>
    {
        new Admin { Username = "admin", Password = "password123" }
    };

    public bool Authenticate(string username, string password)
    {
        foreach (var admin in admins)
        {
            if (admin.Username == username && admin.Password == password)
            {
                return true;
            }
        }
        return false;
    }
}
}
