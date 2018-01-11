using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class ConsultationResultConfiguration : EntityTypeConfiguration<ConsultationResult>
    {
        public ConsultationResultConfiguration()
        {
            this.ToTable("dbo.ConsultationResult");
            this.HasKey<int>(s => s.ConsultationResultID);
        }
    }
}
