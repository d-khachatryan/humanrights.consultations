using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class GenderItem
    {
        [ScaffoldColumn(false)]
        public int GenderID { get; set; }

        [MaxLength(10)]
        [Display(Name = "Սեռ")]
        public string GenderName { get; set; }
    }
}
