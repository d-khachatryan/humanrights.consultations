using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ProcessStatusItem
    {
        [ScaffoldColumn(false)]
        public int ProcessStatusID { get; set; }

        [MaxLength(250)]
        [Display(Name = "Ընթացք")]
        public string ProcessStatusName { get; set; }
    }
}
