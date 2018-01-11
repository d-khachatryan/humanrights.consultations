using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ConsultantItem
    {
        [ScaffoldColumn(false)]
        public int ConsultantID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [MaxLength(128)]
        [Display(Name = "Նույնականացման համար")]
        public string Id { get; set; }
    }
}
