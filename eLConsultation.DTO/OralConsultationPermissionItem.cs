using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationPermissionItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int OralConsultationPermissionID { get; set; }

        public int? OralConsultationID { get; set; }

        [Display(Name = "Գործարկող")]
        [StringLength(128, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 128 սիմվոլ")]
        public string UserID { get; set; }

        [Display(Name = "Դիտել")]
        public bool? IsRead { get; set; }
        [Display(Name = "Խմբագրել")]
        public bool? IsChange { get; set; }

        [Display(Name = "Գործարկող")]
        public string UserName { get; set; }

        public Guid? GUID { get; set; }
    }
}
