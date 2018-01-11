using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class IssueCategoryItem
    {
        public int IssueCategoryID { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        public string IssueCategoryName { get; set; }
    }
}
