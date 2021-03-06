﻿using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationDeclarationTypeDetail
    {
        [Required, Key]
        public int TypeConsultationDeclarationTypeID { get; set; }

        public int? TypeConsultationID { get; set; }

        [Display(Name = "Գրության տիպ")]
        public int? DeclarationTypeID { get; set; }

        [Display(Name = "Գրության տիպ")]
        public string DeclarationTypeName { get; set; }

        [Display(Name = "---")]
        public string DeclarationURL { get; set; }

        [Display(Name = "Վերջնաժամկետ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeclarationDeadline { get; set; }

        [Display(Name = "Գրության ուղարկման ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeclarationDate { get; set; }

        [Display(Name = "Գրության ուղարկման ամսաթիվ")]
        public int? OrganizationID { get; set; }

        [Display(Name = "Կառույց որին ուղարկվել է գրություն")]
        public string OrganizationName { get; set; }

        [Display(Name = "Պատասխանի ստացման ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ResponseDate { get; set; }

        [Display(Name = "Պատասխան գրության ժամկետ")]
        public int? ResponseTypeID { get; set; }

        [Display(Name = "Պատասխան գրության ժամկետ")]
        public string ResponseTypeName { get; set; }

        [Display(Name = "Պատասխան գրության հղում")]
        public string ResponseContent { get; set; }

        [Display(Name = "Պատասխանի էություն")]
        public int? ResponseQualityID { get; set; }

        [Display(Name = "Պատասխանի էություն")]
        public string ResponseQualityName { get; set; }
    }
}
