using Microsoft.AspNetCore.Identity;

namespace Layers.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
