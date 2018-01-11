using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ConsultationTypeItem
    {
        [ScaffoldColumn(false)]
        public int ConsultationTypeID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Տեսակ")]
        public string ConsultationTypeName { get; set; }
    }
}
