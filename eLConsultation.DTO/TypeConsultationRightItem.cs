using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationRightItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int TypeConsultationRightID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Իրավունք")]
        public int? HumanRightID { get; set; }
        [Display(Name = "Իրավունք")]
        public string HumanRightName { get; set; }

        public Guid? GUID { get; set; }
    }
}
