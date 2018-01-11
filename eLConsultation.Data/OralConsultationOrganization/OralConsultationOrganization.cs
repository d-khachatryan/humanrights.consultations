using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationOrganization
    {
        public int OralConsultationOrganizationID { get; set; }

        public int? OralConsultationID { get; set; }

        public int? OrganizationID { get; set; }

        public OralConsultation OralConsultation { get; set; }
    }
}
