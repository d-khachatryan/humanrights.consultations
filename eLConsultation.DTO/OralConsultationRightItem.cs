using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationRightItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int OralConsultationRightID { get; set; }

        public int? OralConsultationID { get; set; }

        [Display(Name = "Իրավունք")]
        public int? HumanRightID { get; set; }

        [Display(Name = "Իրավունք")]
        public string HumanRightName { get; set; }

        public Guid? GUID { get; set; }
    }
}
