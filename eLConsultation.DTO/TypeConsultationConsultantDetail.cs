using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationConsultantDetail
    {
        [Required, Key]
        
        public int TypeConsultationConsultantID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Խորհրդատու")]
        public int? ConsultantID { get; set; }
        [Display(Name = "Խորհրդատու")]
        public string ConsultantName { get; set; }

    }
}
