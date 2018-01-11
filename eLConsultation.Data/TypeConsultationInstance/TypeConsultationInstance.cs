using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationInstance
    {
        public int TypeConsultationInstanceID { get; set; }

        public int? TypeConsultationID { get; set; }

        public int? OrganizationID { get; set; }

        public TypeConsultation TypeConsultation { get; set; }
    }
}
