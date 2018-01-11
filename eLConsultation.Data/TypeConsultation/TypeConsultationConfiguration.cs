using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationConfiguration : EntityTypeConfiguration<TypeConsultation>
    {
        public TypeConsultationConfiguration()
        {
            this.ToTable("dbo.TypeConsultation");
            this.HasKey<int>(s => s.TypeConsultationID);
            this.Property(s => s.TypeConsultationID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
