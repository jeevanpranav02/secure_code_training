using PublicKeyCryptography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicKeyCryptography.Services
{
    public class AdminService
    {
        private readonly List<Admin> admins = new List<Admin>
        {
            new Admin { Username = "admin", Password = "password" }
        };

        public bool Authenticate(string username, string password)
        {
            return admins.Exists(a => a.Username == username && a.Password == password);
        }
    }
}
