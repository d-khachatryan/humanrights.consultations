using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class CompanyItem
    {
        [Required]
        public int CompanyID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Անվանումը պարտադիր է")]
        [Display(Name = "Անվանում")]
        public string CompanyName { get; set; }

        public InitializationTypes InitializationType { get; set; }
    }
}
