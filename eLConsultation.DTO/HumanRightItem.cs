using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class HumanRightItem
    {
        [ScaffoldColumn(false)]
        public int HumanRightID { get; set; }

        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        [Display(Name = "Իրավունք")]
        public string HumanRightName { get; set; }
    }
}
