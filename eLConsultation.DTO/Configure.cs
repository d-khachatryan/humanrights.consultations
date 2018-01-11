using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class Configure
    {
        [Display(Name ="SMTP Սերվեր")]
        [Required(ErrorMessage = "Սերվերը պարտադիր է")]
        public string SMTP_Server { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "SMTP Գաղտնաբառ")]
        [Required(ErrorMessage = "Գաղտնաբառը պարտադիր է")]
        public string SMTP_Password { get; set; }

        [EmailAddress]
        [Display(Name = "SMTP Էլ․ փոստի հասցե")]
        [Required(ErrorMessage = "Էլ․ փոստի հասցեն պարտադիր է")]
        public string SMTP_Email { get; set; }

        [Display(Name = "SMTP Պորտ")]
        [Required(ErrorMessage = "Պորտը պարտադիր է")]
        public string SMTP_Port { get; set; }

        [Display(Name = "SMTP Առաքման մեթոդ")]
        [Required(ErrorMessage = "Առաքման մեթոդը պարտադիր է")]
        public int SMTP_DeliveryMethod { get; set; }

        [Display(Name = "Կիրառել սկզբնական լիազորությունները")]
        public bool SMTP_UseDefaultCredentials { get; set; }

        [Display(Name = "Կիրառել SSL")]
        public bool SMTP_EnableSsl { get; set; }

        [Display(Name = "Գործարկող")]
        [Required(ErrorMessage = "Գործարկողը պարտադիր է")]
        public string User_UserName { get; set; }

        [Display(Name = "Անուն")]
        public string User_FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string User_LastName { get; set; }

        [Display(Name = "Գործարկողի Էլ․ Փոստ")]
        [Required(ErrorMessage = "Էլ․ Փոստը պարտադիր է")]
        public string User_Email { get; set; }

        [Required(ErrorMessage = "Գաղտնաբառը պարտադիր է")]
        [Display(Name = "Գործարկողի Գաղտնաբառ")]
        public string User_Password { get; set; }

        [Display(Name = "Հաստատել գաղտնաբառը")]
        [Required(ErrorMessage = "Հաստատել գաղտնաբառը պարտադիր է")]
        [Compare("User_Password", ErrorMessage = "Գաղտնաբառը և հաստատումը չեն համընկնում")]
        public string User_ConfirmPassword { get; set; }
    }
}
