using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class RegionItem
    {
        [ScaffoldColumn(false)]
        public int RegionID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Մարզ")]
        public string RegionName { get; set; }
    }
}
