using RBAC.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Models
{
    public class User
    {
        public string Name { get; set; }
        public Role UserRole { get; set; }

        public User(string name, Role role)
        {
            Name = name;
            UserRole = role;
        }
    }
}
