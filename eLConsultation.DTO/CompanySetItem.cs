using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class CompanySetItem
    {
        public int CompanyID { get; set; }

        [Display(Name = "Անվանում")]
        public string CompanyName { get; set; }
    }
}
