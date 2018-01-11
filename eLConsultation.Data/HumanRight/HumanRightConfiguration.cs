using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class HumanRightConfiguration : EntityTypeConfiguration<HumanRight>
    {
        public HumanRightConfiguration()
        {
            this.ToTable("dbo.HumanRight");
            this.HasKey<int>(s => s.HumanRightID);
        }
    }
}
