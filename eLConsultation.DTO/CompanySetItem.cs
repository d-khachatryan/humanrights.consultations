using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class CompanySetItem
    {
        public int CompanyID { get; set; }

        [Display(Name = "Անվանում")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string CompanyName { get; set; }
    }
}
