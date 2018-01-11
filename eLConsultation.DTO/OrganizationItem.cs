using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OrganizationItem
    {
        [ScaffoldColumn(false)]
        public int OrganizationID { get; set; }

        [MaxLength(250)]
        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }
    }
}
