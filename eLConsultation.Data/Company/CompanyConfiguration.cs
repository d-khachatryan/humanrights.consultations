using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            this.ToTable("dbo.Company");
            this.HasKey<int>(s => s.CompanyID);
            this.Property(s => s.CompanyID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
