using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class ConsultantConfiguration : EntityTypeConfiguration<Consultant>
    {
        public ConsultantConfiguration()
        {
            this.ToTable("dbo.Consultant");
            this.HasKey<int>(s => s.ConsultantID);
        }
    }
}
