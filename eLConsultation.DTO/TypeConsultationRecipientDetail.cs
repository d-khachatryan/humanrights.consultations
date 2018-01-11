using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationRecipientDetail
    {
        [Required, Key]
        public int TypeConsultationRecipientID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Գրության ուղարկման ամսաթիվ")]
        public DateTime? RecipientDate { get; set; }

        [Display(Name = "Կառույց")]
        public int? OrganizationID { get; set; }

        [Display(Name = "Կառույց")]
        public string OrganizationName { get; set; }
    }
}
