using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class InvocationTypeItem
    {
        [ScaffoldColumn(false)]
        public int InvocationTypeID { get; set; }

        [MaxLength(250)]
        [Display(Name = "Դիմելու ձև")]
        public string InvocationTypeName { get; set; }
    }
}
