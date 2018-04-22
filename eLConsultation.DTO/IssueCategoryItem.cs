using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class IssueCategoryItem
    {
        public int IssueCategoryID { get; set; }

        [Display(Name = "Խնդրի կատեգորիան")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string IssueCategoryName { get; set; }
    }
}
