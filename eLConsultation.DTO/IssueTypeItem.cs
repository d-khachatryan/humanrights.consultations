using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class IssueTypeItem
    {
        public int IssueTypeID { get; set; }

        [Display(Name = "Խնդրի տեսակ")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string IssueTypeName { get; set; }
    }
}
