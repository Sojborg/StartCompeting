using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastruture
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base ("AuthContext")
        {
            
        }
    }
}