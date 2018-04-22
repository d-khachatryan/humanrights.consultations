using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class InvocationTypeItem
    {
        [ScaffoldColumn(false)]
        public int InvocationTypeID { get; set; }

        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        [Display(Name = "Դիմելու ձև")]
        public string InvocationTypeName { get; set; }
    }
}
