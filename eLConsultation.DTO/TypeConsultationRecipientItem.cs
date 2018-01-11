using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationRecipientItem
    {
        [Required, Key]
        public int ID { get; set; }

        public int TypeConsultationRecipientID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Գրության ուղարկման ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RecipientDate { get; set; }

        [Display(Name = "Կառույց")]
        public int? OrganizationID { get; set; }

        [Display(Name = "Կառույց")]
        public string OrganizationName { get; set; }

        public Guid? GUID { get; set; }
    }
}
