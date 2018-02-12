using eLConsultation.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ResidentOralConsultationSet
    {
        public int IssueID { get; set; }
        [Display(Name = "Քաղաքացի")]
        public int? ResidentID { get; set; }

        [Display(Name = "Խնդրի անվանումը")]
        public string IssueName { get; set; }

        [Display(Name = "Խնդրի նկարագրությունը")]
        public string IssueDescription { get; set; }

        [Display(Name = "Խնդրի ա/թ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IssueDate { get; set; }

        [Display(Name = "Խնդրի տեսակը")]
        public int? IssueTypeID { get; set; }

        [Display(Name = "Խնդրի տեսակը")]
        public string IssueTypeName { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        public int? IssueCategoryID { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        public string IssueCategoryName { get; set; }

        public int OralConsultationID {get;set;}
                               
        [Required(AllowEmptyStrings = false, ErrorMessage = "Խորհրդատվության ամսաթիվը պարտադիր է")]
        [Display(Name = "Խորհրդատվության ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OralConsultationDate { get; set; }

        public int? InvocationTypeID { get; set; }
        [Display(Name = "Դիմելու ձևը")]
        public string InvocationTypeName { get; set; }

        public int? TargetGroupID { get; set; }
        [Display(Name = "Թիրախային խումբ")]
        public string TargetGroupName { get; set; }

        [Display(Name = "Խնդիր")]
        public string ProblemDescription { get; set; }

        [Display(Name = "Խորհրդատվություն")]
        public string ConsultationDescription { get; set; }
    }
}
