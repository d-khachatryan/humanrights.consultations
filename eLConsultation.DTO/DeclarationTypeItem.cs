using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class DeclarationTypeItem
    {
        [ScaffoldColumn(false)]
        public int DeclarationTypeID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Հայտարարություն")]
        public string DeclarationTypeName { get; set; }
    }
}
