using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationOrganizationItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int OralConsultationOrganizationID { get; set; }

        public int? OralConsultationID { get; set; }

        [Display(Name = "Կառույց")]
        public int? OrganizationID { get; set; }

        [Display(Name = "Կառույց")]
        public string OrganizationName { get; set; }

        public Guid? GUID { get; set; }
    }
}
