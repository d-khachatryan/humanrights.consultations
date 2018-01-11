using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ResetPasswordItem
    {
        [Required(ErrorMessage = "Էլ․ փոստը պարտադիր է")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Գաղտնաբառը պարտադիր է")]
        [StringLength(100, ErrorMessage = "{0}ը պետք է պարունակի առնվազն {2} նիշ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Գաղտնաբառ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Գաղտնաբառը և հաստատումը չեն համընկնում")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
