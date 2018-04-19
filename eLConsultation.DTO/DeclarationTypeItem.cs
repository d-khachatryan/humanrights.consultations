using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class DeclarationTypeItem
    {
        [ScaffoldColumn(false)]
        public int DeclarationTypeID { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        [Display(Name = "Հայտարարություն")]
        public string DeclarationTypeName { get; set; }
    }
}
