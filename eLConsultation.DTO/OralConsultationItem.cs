using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class OralConsultationItem
    {
        [Required]
        [Display(Name = "Խորհրդատվության համար")]
        public int OralConsultationID { get; set; }        
        //public int? ResidentID { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string MiddleName { get; set; }

        //[Display(Name = "Նույնականացման համար")]
        //public string IdentificatorNumber { get; set; }

        //[Display(Name = "Ծննդյան ամսաթիվ")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? BirthDate { get; set; }

        public int? IssueID { get; set; }

        [Display(Name = "Խնդրի անվանում")]
        public string IssueName { get; set; }

        [Display(Name = "Խնդրի նկարագրություն")]
        public string IssueDescription { get; set; }

        [Display(Name = "Խնդրի ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IssueDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Խորհրդատվության ամսաթիվը պարտադիր է")]
        [Display(Name = "Խորհրդատվության ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OralConsultationDate { get; set; }

        [Display(Name = "Դիմելու ձևը")]
        public int? InvocationTypeID { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        public int? TargetGroupID { get; set; }

        [Display(Name = "Խնդրի նկարագրություն")]
        [AllowHtml]
        public string ProblemDescription { get; set; }

        [Display(Name = "Խորհրդատվություն")]
        [AllowHtml]
        public string ConsultationDescription { get; set; }

        public Guid? GUID { get; set; }

        public InitializationTypes InitializationType { get; set; }

        public string UserID { get; set; }

        public DateTime? ChangeDate { get; set; }

        //public string ResidentName { get
        //    {
        //        return FirstName + " " + MiddleName + " " + LastName; 
        //    }
        //}
    }
}
