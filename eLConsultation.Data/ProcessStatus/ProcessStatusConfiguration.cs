using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    class ProcessStatusConfiguration : EntityTypeConfiguration<ProcessStatus>
    {
        public ProcessStatusConfiguration()
        {
            this.ToTable("dbo.ProcessStatus");
            this.HasKey<int>(s => s.ProcessStatusID);
        }
    }
}
