using System.Collections.Generic;

namespace ItServiceApp.Models
{
    public static class RoleModels
    {
        public static string Admin = "Admin";
        public static string User = "User";

        public static ICollection<string> Roles => new List<string>() { Admin, User };


    }
}
