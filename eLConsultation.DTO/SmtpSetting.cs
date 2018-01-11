using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class SmtpSetting
    {
        [Display(Name ="Սերվեր")]
        [Required(ErrorMessage = "Սերվերը պարտադիր է")]
        public string Server { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Գաղտնաբառ")]
        [Required(ErrorMessage = "Գաղտնաբառը պարտադիր է")]
        public string Password { get; set; }

        [EmailAddress]
        [Display(Name = "Էլ․ փոստի հասցե")]
        [Required(ErrorMessage = "Էլ․ փոստի հասցեն պարտադիր է")]
        public string Email { get; set; }

        [Display(Name = "Պորտ")]
        [Required(ErrorMessage = "Պորտը պարտադիր է")]
        public string Port { get; set; }

        [Display(Name = "Առաքման մեթոդ")]
        [Required(ErrorMessage = "Առաքման մեթոդը պարտադիր է")]
        public int DeliveryMethod { get; set; }

        [Display(Name = "Կիրառել սկզբնական լիազորությունները")]
        public bool UseDefaultCredentials { get; set; }

        [Display(Name = "Կիրառել SSL")]
        public bool EnableSsl { get; set; }
    }
}
