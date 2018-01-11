using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TmpOralConsultationRight
    {
        public int ID { get; set; }

        public int OralConsultationRightID { get; set; }

        public int? OralConsultationID { get; set; }

        public int? HumanRightID { get; set; }

        public Guid? GUID { get; set; }
    }
}
