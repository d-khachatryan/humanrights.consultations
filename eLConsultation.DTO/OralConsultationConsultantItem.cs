using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationConsultantItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int OralConsultationConsultantID { get; set; }

        public int? OralConsultationID { get; set; }

        [Display(Name = "Խորհրդատու")]
        public int? ConsultantID { get; set; }

        [Display(Name = "Խորհրդատու")]
        public string ConsultantName { get; set; }

        public Guid? GUID { get; set; }
    }
}
