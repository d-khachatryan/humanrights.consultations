using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class CompanyTypeConsultationSet
    {
        public int IssueID { get; set; }
        [Display(Name = "Քաղաքացի")]
        public int? CompanyID { get; set; }

        [Display(Name = "Խնդրի անվանումը")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
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
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string IssueTypeName { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        public int? IssueCategoryID { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string IssueCategoryName { get; set; }

        public int TypeConsultationID { get; set; }

        [Display(Name = "Գործի անվանում")]
        [StringLength(500, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 500 սիմվոլ")]
        public string TypeConsultationName { get; set; }
                
        [Display(Name = "Ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TypeConsultationDate { get; set; }

        public int? ConsultationTypeID { get; set; }

        [Display(Name = "Գործի տիպ")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string ConsultationTypeName { get; set; }

        public int? ProcessStatusID { get; set; }

        [Display(Name = "Գործի կարգավիճակ")]
        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        public string ProcessStatusName { get; set; }

        public int? ConsultationResultID { get; set; }

        [Display(Name = "Գործի արդյունք")]
        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        public string ConsultationResultName { get; set; }

        public int? TargetGroupID { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        public string TargetGroupName { get; set; }
    }
}
