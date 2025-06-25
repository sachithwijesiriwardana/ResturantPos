using Microsoft.AspNetCore.Identity;

namespace ResturantPos.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ICollection<Order>?Orders { get; set; }
    }
}
