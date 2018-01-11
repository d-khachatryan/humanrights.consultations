using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationOrganizationDetail
    {
        [Required, Key]
        public int OralConsultationOrganizationID { get; set; }

        public int? OralConsultationID { get; set; }

        [Display(Name = "Կառույց")]
        public int? OrganizationID { get; set; }

        [Display(Name = "Կառույց")]
        public string OrganizationName { get; set; }
    }
}
