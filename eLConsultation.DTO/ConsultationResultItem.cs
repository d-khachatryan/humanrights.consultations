using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ConsultationResultItem
    {
        [ScaffoldColumn(false)]
        public int ConsultationResultID { get; set; }

        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        [Display(Name = "Արդյունք")]
        public string ConsultationResultName { get; set; }
    }
}
