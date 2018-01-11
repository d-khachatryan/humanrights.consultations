using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class ConsultationTypeConfiguration : EntityTypeConfiguration<ConsultationType>
    {
        public ConsultationTypeConfiguration()
        {
            this.ToTable("dbo.ConsultationType");
            this.HasKey<int>(s => s.ConsultationTypeID);
        }
    }
}
