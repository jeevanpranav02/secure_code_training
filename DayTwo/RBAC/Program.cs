using RBAC.Enums;
using RBAC.Models;

namespace RBAC_Radiology
{
    public class Program
    {
        static readonly Dictionary<Role, Permission> RolePermissions = new Dictionary<Role, Permission>
        {
            { Role.Radiologist, Permission.Read | Permission.Create | Permission.Update | Permission.Delete },
            { Role.Physician, Permission.Read | Permission.Update },
            { Role.LabTechnician, Permission.Read | Permission.Update },
            { Role.Administrator, Permission.Read | Permission.Create | Permission.Update | Permission.Delete },
            { Role.Patient, Permission.Read },
            { Role.BillingStaff, Permission.Read }
        };

        static readonly Dictionary<string, User> Users = new Dictionary<string, User>();
        static void LoadUsersFromCSV(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found at {filePath}");
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }

                    string[] data = line.Split(',');

                    if (data.Length == 2 && Enum.TryParse(data[1].Trim(), out Role role))
                    {
                        Users[data[0].Trim()] = new User(data[0].Trim(), role);
                    }
                }
            }
        }

        static bool HasPermission(User user, Permission action/*, bool hasAssociatedTreatment = false*/)
        {
            //if (user.UserRole == Role.Radiologist && action == Permission.Delete)
            //{
            //    return !hasAssociatedTreatment; // Radiologists can delete only if no associated treatment
            //}

            return (RolePermissions[user.UserRole] & action) == action;
        }

        static void PrintPermissionTable()
        {
            Console.WriteLine("\n{0,-12} {1,-15} {2,-7} {3,-5} {4,-7} {5,-7}", "User", "Role", "Create", "Read", "Update", "Delete");
            Console.WriteLine("------------------------------------------------------");

            foreach (var entry in Users)
            {
                User user = entry.Value;
                Console.WriteLine("{0,-12} {1,-15} {2,-7} {3,-5} {4,-7} {5,-7}",
                    user.Name,
                    $"({user.UserRole})",
                    HasPermission(user, Permission.Create),
                    HasPermission(user, Permission.Read),
                    HasPermission(user, Permission.Update),
                    HasPermission(user, Permission.Delete/*, hasAssociatedTreatment: true*/));
            }

        }

        static void Main()
        {
            string filePath = "data/data.csv";
            LoadUsersFromCSV(filePath);
            PrintPermissionTable();
        }
    }
}