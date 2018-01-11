using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class IssueSetItem
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

        [Display(Name = "Կազմակերպություն")]
        public int? CompanyID { get; set; }

        [Display(Name = "Կազմակերպություն")]
        public string CompanyName { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        public int? IssueCategoryID { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        public string IssueCategoryName { get; set; }
    }
}
