using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SapnaWebsite.Models
{
    public class User: IdentityUser<int>
    {
        public Member Member { get; set; } = new Member();
    }
}
