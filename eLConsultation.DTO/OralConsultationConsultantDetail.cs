using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationConsultantDetail
    {
        [Required, Key]
        public int OralConsultationConsultantID { get; set; }

        public int? OralConsultationID { get; set; }

        [Display(Name = "Խորհրդատու")]
        public int? ConsultantID { get; set; }

        [Display(Name = "Խորհրդատու")]
        public string ConsultantName { get; set; }
    }
}
