using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    class IssueCategoryConfiguration : EntityTypeConfiguration<IssueCategory>
    {
        public IssueCategoryConfiguration()
        {
            this.ToTable("dbo.IssueCategory");
            this.HasKey<int>(s => s.IssueCategoryID);
            this.Property(s => s.IssueCategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.IssueCategoryName).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
