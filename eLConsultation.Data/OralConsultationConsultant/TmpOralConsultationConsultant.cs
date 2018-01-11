using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TmpOralConsultationConsultant
    {
        public int ID { get; set; }

        public int OralConsultationConsultantID { get; set; }

        public int? OralConsultationID { get; set; }

        public int? ConsultantID { get; set; }

        public Guid? GUID { get; set; }
    }
}
