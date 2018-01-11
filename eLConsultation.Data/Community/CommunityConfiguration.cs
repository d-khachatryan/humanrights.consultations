using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class CommunityConfiguration : EntityTypeConfiguration<Community>
    {
        public CommunityConfiguration()
        {
            this.ToTable("dbo.Community");
            this.HasKey<int>(s => s.CommunityID);
        }
    }
}
