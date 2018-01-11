using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationSearch
    {
        public int TypeConsultationSearchID { get; set; }

        //public Guid? SearchGUID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Գործի անվանում")]
        public string TypeConsultationName { get; set; }

        public DateTime? TypeConsultationDate { get; set; }

        public int? TypeConsultationID { get; set; }
    }
}
