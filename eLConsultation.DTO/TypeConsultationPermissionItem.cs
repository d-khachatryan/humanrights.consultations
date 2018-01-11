using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationPermissionItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int TypeConsultationPermissionID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Գործարկող")]
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
