using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationSetItem
    {
        [Required]
        [Display(Name = "Խորհրդատվության համար")]
        public int OralConsultationID { get; set; }

        public int? ResidentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Display(Name = "Նույնականացման համար")]
        public string IdentificatorNumber { get; set; }

        [Display(Name = "Ծննդյան ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Խորհրդատվության ամսաթիվը պարտադիր է")]
        [Display(Name = "Խորհրդատվության ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OralConsultationDate { get; set; }

        [Display(Name = "Դիմելու ձևը")]
        public int? InvocationTypeID { get; set; }

        [Display(Name = "Դիմելու ձևը")]
        public string InvocationTypeName { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        public int? TargetGroupID { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        public string TargetGroupName { get; set; }

        public string ResidentName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}
