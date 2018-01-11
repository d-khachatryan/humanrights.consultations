using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ResidentConfiguration : EntityTypeConfiguration<Resident>
    {
        public ResidentConfiguration()
        {
            this.ToTable("dbo.Resident");
            this.HasKey<int>(s => s.ResidentID);
            this.Property(s => s.ResidentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
