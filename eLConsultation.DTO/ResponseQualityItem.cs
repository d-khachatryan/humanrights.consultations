using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ResponseQualityItem
    {
        public int ResponseQualityID { get; set; }

        [Display(Name = "------")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        public string ResponseQualityName { get; set; }
    }
}
