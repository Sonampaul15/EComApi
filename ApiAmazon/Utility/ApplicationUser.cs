using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiAmazon.Utility
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }=string.Empty;

        public string LastName { get; set; }= string.Empty;

        public string Gender { get; set; } = string.Empty;  
    }
}
