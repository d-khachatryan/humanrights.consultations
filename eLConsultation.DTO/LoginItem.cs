using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class LoginItem
    {
        [Required(ErrorMessage = "Մուտքանունը պարտադիր է")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Գաղտնաբառը պարտադիր է")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Հիշել ինձ")]
        public bool RememberMe { get; set; }
    }
}
