using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationRight
    {
        public int TypeConsultationRightID { get; set; }

        public int? TypeConsultationID { get; set; }

        public int? HumanRightID { get; set; }

        public TypeConsultation TypeConsultation { get; set; }
    }
}
