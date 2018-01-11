using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationRightDetail
    {
        [Required, Key]
        public int TypeConsultationRightID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Իրավունք")]
        public int? HumanRightID { get; set; }
        [Display(Name = "Իրավունք")]
        public string HumanRightName { get; set; }
    }
}
