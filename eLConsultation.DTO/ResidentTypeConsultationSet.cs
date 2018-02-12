using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ResidentTypeConsultationSet
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

        public int TypeConsultationID { get; set; }

        [Display(Name = "Գործի անվանում")]
        public string TypeConsultationName { get; set; }
                
        [Display(Name = "Ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TypeConsultationDate { get; set; }

        public int? ConsultationTypeID { get; set; }

        [Display(Name = "Գործի տիպ")]
        public string ConsultationTypeName { get; set; }

        public int? ProcessStatusID { get; set; }

        [Display(Name = "Գործի կարգավիճակ")]
        public string ProcessStatusName { get; set; }

        public int? ConsultationResultID { get; set; }

        [Display(Name = "Գործի արդյունք")]
        public string ConsultationResultName { get; set; }

        public int? TargetGroupID { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        public string TargetGroupName { get; set; }
    }
}
