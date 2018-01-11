using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationConsultant
    {
        public int OralConsultationConsultantID { get; set; }

        public int? OralConsultationID { get; set; }

        public int? ConsultantID { get; set; }

        public OralConsultation OralConsultation { get; set; }
    }
}
