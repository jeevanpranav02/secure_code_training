using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Enums
{
    [Flags]
    public enum Permission
    {
        None = 0,
        Read = 1,
        Create = 2,
        Update = 4,
        Delete = 8
    }
}
