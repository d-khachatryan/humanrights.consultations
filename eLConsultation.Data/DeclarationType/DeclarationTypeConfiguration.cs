using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class DeclarationTypeConfiguration : EntityTypeConfiguration<DeclarationType>
    {
        public DeclarationTypeConfiguration()
        {
            this.ToTable("dbo.DeclarationType");
            this.HasKey<int>(s => s.DeclarationTypeID);
        }
    }
}
