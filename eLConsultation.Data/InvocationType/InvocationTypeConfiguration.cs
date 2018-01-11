using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class InvocationTypeConfiguration : EntityTypeConfiguration<InvocationType>
    {
        public InvocationTypeConfiguration()
        {
            this.ToTable("dbo.InvocationType");
            this.HasKey<int>(s => s.InvocationTypeID);
        }
    }
}
