using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationSetItem
    {
        [Required]
        [Display(Name = "Խորհրդատվության համար")]
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Խորհրդատվության ամսաթիվը պարտադիր է")]
        [Display(Name = "Խորհրդատվության ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TypeConsultationDate { get; set; }

        [Display(Name = "Գործի տիպ")]
        public int? ConsultationTypeID { get; set; }

        [Display(Name = "Գործի տիպ")]
        public string ConsultationTypeName { get; set; }

        [Display(Name = "Գործի կարգավիճակ")]
        public int? ProcessStatusID { get; set; }

        [Display(Name = "Գործի կարգավիճակ")]
        public string ProcessStatusName { get; set; }

        [Display(Name = "Գործի արդյունք")]
        public int? ConsultationResultID { get; set; }

        [Display(Name = "Գործի արդյունք")]
        public string ConsultationResultName { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        public int? TargetGroupID { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        public string TargetGroupName { get; set; }

        public string ResidentName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}
