using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TmpTypeConsultationConsultant
    {
        public int ID { get; set; }

        public int TypeConsultationConsultantID { get; set; }

        public int? TypeConsultationID { get; set; }

        public int? ConsultantID { get; set; }

        public Guid? GUID { get; set; }
    }
}
