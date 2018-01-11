using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationRight
    {
        public int OralConsultationRightID { get; set; }

        public int? OralConsultationID { get; set; }

        public int? HumanRightID { get; set; }

        public OralConsultation OralConsultation { get; set; }
    }
}