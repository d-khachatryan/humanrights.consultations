using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationRightDetail
    {
        [Required, Key]
        public int OralConsultationRightID { get; set; }

        public int? OralConsultationID { get; set; }

        [Display(Name = "Իրավունք")]
        public int? HumanRightID { get; set; }

        [Display(Name = "Իրավունք")]
        public string HumanRightName { get; set; }
    }
}
