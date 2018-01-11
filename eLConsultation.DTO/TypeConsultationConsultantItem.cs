using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationConsultantItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int TypeConsultationConsultantID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Խորհրդատու")]
        public int? ConsultantID { get; set; }
        [Display(Name = "Խորհրդատու")]
        public string ConsultantName { get; set; }

        public Guid? GUID { get; set; }
    }
}
