using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ConsultationTypeItem
    {
        [ScaffoldColumn(false)]
        public int ConsultationTypeID { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        [Display(Name = "Տեսակ")]
        public string ConsultationTypeName { get; set; }
    }
}
