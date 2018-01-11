using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class AspNetUsersConfiguration : EntityTypeConfiguration<AspNetUsers>
    {
        public AspNetUsersConfiguration()
        {
            this.ToTable("dbo.AspNetUsers");
            this.HasKey<string>(s => s.Id);
        }
    }
}
