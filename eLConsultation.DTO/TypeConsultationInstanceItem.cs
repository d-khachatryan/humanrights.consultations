using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationInstanceItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int TypeConsultationInstanceID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Կառույց")]
        public int? OrganizationID { get; set; }
        [Display(Name = "Կառույց")]
        public string OrganizationName { get; set; }

        public Guid? GUID { get; set; }
    }
}
