using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasscodeHandling.Models
{
    public class Admin
    {
        public string Username { get; set; }
        public string HashedPasscode { get; set; }
    }
}
