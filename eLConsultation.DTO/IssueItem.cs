using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class IssueItem
    {
        public int IssueID { get; set; }

        [Display(Name = "Քաղաքացի")]
        public int? ResidentID { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Display(Name = "Ա․Հ․Փ․")]
        public string IdentificatorNumber { get; set; }

        [Display(Name = "Ծննդյան ա/թ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Խնդրի անվանումը")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Խնդրի անվանումը պարտադիր է")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string IssueName { get; set; }

        [Display(Name = "Խնդրի նկարագրությունը")]
        [AllowHtml]
        public string IssueDescription { get; set; }

        [Display(Name = "Դիմելու ա/թ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Դիմելու ամսաթիվը պարտադիր է")]
        public DateTime? IssueDate { get; set; }

        [Display(Name = "Խնդրի տեսակը")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Խնդրի տեսակը պարտադիր է")]
        public int? IssueTypeID { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Խնդրի կատեգորիան պարտադիր է")]
        public int? IssueCategoryID { get; set; }

        [Display(Name = "Կազմակերպություն")]
        public int? CompanyID { get; set; }

        [Display(Name = "Կազմակերպություն")]
        public string CompanyName { get; set; }

        public InitializationTypes InitializationType { get; set; }
        public ConsultationTypes? ConsultationType { get; set; }
    }
}
