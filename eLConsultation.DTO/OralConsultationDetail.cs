using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class OralConsultationDetail
    {
        public OralConsultationDetail()
        {
            OralConsultationConsultantDetails = new List<OralConsultationConsultantDetail>();
            OralConsultationOrganizationDetails = new List<OralConsultationOrganizationDetail>();
            OralConsultationRightDetails = new List<OralConsultationRightDetail>();
        }

        public int OralConsultationID { get; set; }
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
        public DateTime? OralConsultationDate { get; set; }

        public int? InvocationTypeID { get; set; }
        [Display(Name = "Դիմելու ձևը")]
        public string InvocationTypeName { get; set; }

        public int? TargetGroupID { get; set; }
        [Display(Name = "Թիրախային խումբ")]
        public string TargetGroupName { get; set; }

        [Display(Name = "Խնդիր")]
        [AllowHtml]
        public string ProblemDescription { get; set; }

        [Display(Name = "Խորհրդատվություն")]
        public string ConsultationDescription { get; set; }

        public IList<OralConsultationConsultantDetail> OralConsultationConsultantDetails { get; set; }

        public IList<OralConsultationOrganizationDetail> OralConsultationOrganizationDetails { get; set; }

        public IList<OralConsultationRightDetail> OralConsultationRightDetails { get; set; }

    }
}
