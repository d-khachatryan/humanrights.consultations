using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ConsultationResultItem
    {
        [ScaffoldColumn(false)]
        public int ConsultationResultID { get; set; }

        [MaxLength(250)]
        [Display(Name = "Արդյունք")]
        public string ConsultationResultName { get; set; }
    }
}
