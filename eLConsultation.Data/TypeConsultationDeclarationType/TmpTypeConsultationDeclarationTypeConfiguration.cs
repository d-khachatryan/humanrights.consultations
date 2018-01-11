using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class TmpTypeConsultationDeclarationTypeConfiguration : EntityTypeConfiguration<TmpTypeConsultationDeclarationType>
    {
        public TmpTypeConsultationDeclarationTypeConfiguration()
        {
            this.ToTable("dbo.TmpTypeConsultationDeclarationType");
            this.HasKey<int>(s => s.ID);
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
