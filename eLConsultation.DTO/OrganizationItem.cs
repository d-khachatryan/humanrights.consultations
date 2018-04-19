using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OrganizationItem
    {
        [ScaffoldColumn(false)]
        public int OrganizationID { get; set; }

        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }
    }
}
