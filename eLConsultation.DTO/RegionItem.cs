using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class RegionItem
    {
        [ScaffoldColumn(false)]
        public int RegionID { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        [Display(Name = "Մարզ")]
        public string RegionName { get; set; }
    }
}
