using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationRecipient
    {
        public int TypeConsultationRecipientID { get; set; }

        public int? TypeConsultationID { get; set; }

        public DateTime? RecipientDate { get; set; }

        public int? OrganizationID { get; set; }

        public TypeConsultation TypeConsultation { get; set; }
    }
}
