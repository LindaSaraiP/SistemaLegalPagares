using Microsoft.AspNetCore.Identity;

namespace SistemaLegalPagares.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool EstaAprobado { get; set; } = false;
    }
}