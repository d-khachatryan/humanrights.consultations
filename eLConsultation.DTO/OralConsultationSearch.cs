using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationSearch
    {
        public int OralConsultationSearchID { get; set; }

        //public Guid? SearchGUID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? OralConsultationDate { get; set; }

        public int? OralConsultationID { get; set; }
    }
}
