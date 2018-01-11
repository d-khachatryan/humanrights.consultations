using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class IssueTypeItem
    {
        public int IssueTypeID { get; set; }

        [Display(Name = "Խնդրի տեսակ")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        public string IssueTypeName { get; set; }
    }
}
