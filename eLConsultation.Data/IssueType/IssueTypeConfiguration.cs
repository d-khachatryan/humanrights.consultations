using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    class IssueTypeConfiguration : EntityTypeConfiguration<IssueType>
    {
        public IssueTypeConfiguration()
        {
            this.ToTable("dbo.IssueType");
            this.HasKey<int>(s => s.IssueTypeID);
            this.Property(s => s.IssueTypeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.IssueTypeName).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
