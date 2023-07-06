using GoogleAuth.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace GoogleAuth.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}