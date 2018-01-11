using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationPermission
    {
        public int TypeConsultationPermissionID { get; set; }

        public int? TypeConsultationID { get; set; }

        public string UserID { get; set; }

        public bool? IsRead { get; set; }
        public bool? IsChange { get; set; }

        public TypeConsultation TypeConsultation { get; set; }
    }
}
