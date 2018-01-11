using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ForgotPasswordItem
    {
        [Required(ErrorMessage = "Էլ․ փոստի հասցեն պարտադիր է")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
