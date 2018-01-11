using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class TypeConsultationDetail
    {
        public TypeConsultationDetail()
        {
            TypeConsultationConsultantDetails = new List<TypeConsultationConsultantDetail>();
            TypeConsultationInstanceDetails = new List<TypeConsultationInstanceDetail>();
            TypeConsultationDeclarationTypeDetails = new List<TypeConsultationDeclarationTypeDetail>();
            TypeConsultationRecipientDetails = new List<TypeConsultationRecipientDetail>();            
            TypeConsultationRightDetails = new List<TypeConsultationRightDetail>();
        }

        public int TypeConsultationID { get; set; }

        [Display(Name = "Գործի անվանում")]
        public string TypeConsultationName { get; set; }

        public int? ResidentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Display(Name = "Նույնականացման համար")]
        public string IdentificatorNumber { get; set; }

        [Display(Name = "Ծննդյան ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TypeConsultationDate { get; set; }

        public int? ConsultationTypeID { get; set; }

        [Display(Name = "Գործի տիպ")]
        public string ConsultationTypeName { get; set; }

        public int? ProcessStatusID { get; set; }

        [Display(Name = "Գործի կարգավիճակ")]
        public string ProcessStatusName { get; set; }

        public int? ConsultationResultID { get; set; }

        [Display(Name = "Գործի արդյունք")]
        public string ConsultationResultName { get; set; }

        public int? TargetGroupID { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        public string TargetGroupName { get; set; }

        public IList<TypeConsultationConsultantDetail> TypeConsultationConsultantDetails { get; set; }

        public IList<TypeConsultationInstanceDetail> TypeConsultationInstanceDetails { get; set; }

        public IList<TypeConsultationDeclarationTypeDetail> TypeConsultationDeclarationTypeDetails { get; set; }

        public IList<TypeConsultationRecipientDetail> TypeConsultationRecipientDetails { get; set; }

        public IList<TypeConsultationRightDetail> TypeConsultationRightDetails { get; set; }
    }
}
