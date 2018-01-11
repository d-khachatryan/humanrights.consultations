using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationPermission
    {
        public int OralConsultationPermissionID { get; set; }

        public int? OralConsultationID { get; set; }

        public string UserID { get; set; }

        public bool? IsRead { get; set; }
        public bool? IsChange { get; set; }

        public OralConsultation OralConsultation { get; set; }
    }
}
