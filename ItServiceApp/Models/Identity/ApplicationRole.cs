using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ItServiceApp.Models.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }
        public ApplicationRole(string name, string desrciption)
        {
            this.Name = name;
            this.Description = desrciption;
        }
        [StringLength(100)]
        public string Description { get; set; }
    }
}
