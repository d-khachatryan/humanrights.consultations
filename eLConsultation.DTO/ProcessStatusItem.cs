using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ProcessStatusItem
    {
        [ScaffoldColumn(false)]
        public int ProcessStatusID { get; set; }

        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        [Display(Name = "Ընթացք")]
        public string ProcessStatusName { get; set; }
    }
}
