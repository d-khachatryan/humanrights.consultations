using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TmpOralConsultationOrganization
    {
        public int ID { get; set; }

        public int OralConsultationOrganizationID { get; set; }

        public int? OralConsultationID { get; set; }

        public int? OrganizationID { get; set; }

        public Guid? GUID { get; set; }
    }
}
