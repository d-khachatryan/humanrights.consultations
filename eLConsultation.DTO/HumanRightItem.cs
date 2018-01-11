using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class HumanRightItem
    {
        [ScaffoldColumn(false)]
        public int HumanRightID { get; set; }

        [MaxLength(250)]
        [Display(Name = "Իրավունք")]
        public string HumanRightName { get; set; }
    }
}
