using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class Company
    {
        public int CompanyID { get; set; }

        [Display(Name = "Անվանում")]
        public string CompanyName { get; set; }
    }
}
