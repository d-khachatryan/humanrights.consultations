using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class GenderItem
    {
        [ScaffoldColumn(false)]
        public int GenderID { get; set; }

        [StringLength(10, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 10 սիմվոլ")]
        [Display(Name = "Սեռ")]
        public string GenderName { get; set; }
    }
}
