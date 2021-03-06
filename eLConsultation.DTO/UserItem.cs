﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class UserItem
    {
        //[Required(ErrorMessageResourceName = "User_Name_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(100, ErrorMessage = "Դաշտը չի կարող պարունակել քիչ քան 6 և ավելի քան 100 սիմվոլ", MinimumLength = 6)]
        [Display(Name = "Գործարկող")]
        [Required(ErrorMessage = "Գործարկողը պարտադիր է")]
        public string UserName { get; set; }

        //[Required(ErrorMessageResourceName = "User_Email_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        [EmailAddress(ErrorMessage = "Մուտքային տվյալները պետք է համապատասխանեն էլ․ փոստի ֆորմատին")]
        [Display(Name = "Էլ․ Փոստ")]
        [Required(ErrorMessage = "Էլ․ Փոստը պարտադիր է")]
        public string Email { get; set; }

        //[Required(ErrorMessageResourceName = "User_Password_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[StringLength(100, ErrorMessageResourceName = "User_Password_Val", MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.Resources))]
        //[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*(_|[^\\w])).+$", ErrorMessageResourceName = "User_Password_ValGlob", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Դաշտը չի կարող պարունակել քիչ քան 6 և ավելի քան 100 սիմվոլ", MinimumLength = 6)]
        [Required(ErrorMessage = "Գաղտնաբառը պարտադիր է")]
        [Display(Name = "Գաղտնաբառ")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        [Display(Name = "Հաստատել գաղտնաբառը")]
        [Required(ErrorMessage = "Հաստատել գաղտնաբառը պարտադիր է")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Գաղտնաբառը և հաստատումը չեն համընկնում")]
        public string ConfirmPassword { get; set; }

        [Key]
        public string Id { get; set; }

        [Display(Name = "Անուն")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string LastName { get; set; }

        public IList<string> UserItemSelectedRoles { get; set; }
        public IList<SelectListItem> UserItemRoles { get; set; }
        
        public UserItem()
        {
            UserItemRoles = new List<SelectListItem>();
            UserItemSelectedRoles = new List<string>();            
        }
    }

}