using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class UserContext : IdentityDbContext<IdentityUserItem>
    {
        public UserContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static UserContext Create()
        {
            return new UserContext();
        }
    }
}
