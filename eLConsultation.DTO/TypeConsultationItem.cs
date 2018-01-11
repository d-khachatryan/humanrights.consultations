using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationItem
    {
        [Required]
        [Display(Name = "Խորհրդատվության համար")]
        public int TypeConsultationID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Գործի անվանումը պարտադիր է")]
        [Display(Name = "Գործի անվանում")]
        public string TypeConsultationName { get; set; }

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

        public int? IssueID { get; set; }
        public string IssueName { get; set; }
        public string IssueDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IssueDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Խորհրդատվության ամսաթիվը պարտադիր է")]
        [Display(Name = "Խորհրդատվության ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TypeConsultationDate { get; set; }


        [Display(Name = "Գործի տիպ")]
        public int? ConsultationTypeID { get; set; }

        [Display(Name = "Գործի կարգավիճակ")]
        public int? ProcessStatusID { get; set; }

        [Display(Name = "Գործի արդյունք")]
        public int? ConsultationResultID { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        public int? TargetGroupID { get; set; }

        public Guid? GUID { get; set; }

        public InitializationTypes InitializationType { get; set; }

        public string UserID { get; set; }

        public DateTime? ChangeDate { get; set; }

        public string ResidentName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}
