using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class IssueConfiguration : EntityTypeConfiguration<Issue>
    {
        public IssueConfiguration()
        {
            this.ToTable("dbo.Issue");
            this.HasKey<int>(s => s.IssueID);
            this.Property(s => s.IssueID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.IssueName).HasColumnType("nvarchar").HasMaxLength(50);
            this.Property(s => s.IssueName).HasColumnType("nvarchar");
            this.Property(s => s.IssueName).HasColumnType("Date");
            this.HasRequired(c => c.IssueType).WithMany(o => o.Issues).HasForeignKey(o => o.IssueTypeID);
        }
    }
}
