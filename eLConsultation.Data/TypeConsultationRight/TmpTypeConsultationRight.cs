using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TmpTypeConsultationRight
    {
        public int ID { get; set; }

        public int TypeConsultationRightID { get; set; }

        public int? TypeConsultationID { get; set; }

        public int? HumanRightID { get; set; }

        public Guid? GUID { get; set; }
    }
}
