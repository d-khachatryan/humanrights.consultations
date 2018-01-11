using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class TargetGroupConfiguration : EntityTypeConfiguration<TargetGroup>
    {
        public TargetGroupConfiguration()
        {
            this.ToTable("dbo.TargetGroup");
            this.HasKey<int>(s => s.TargetGroupID);
        }
    }
}
