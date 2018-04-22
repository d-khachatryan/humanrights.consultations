using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ConsultantItem
    {
        [ScaffoldColumn(false)]
        public int ConsultantID { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [StringLength(128, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 128 սիմվոլ")]
        [Display(Name = "Նույնականացման համար")]
        public string Id { get; set; }
    }
}
