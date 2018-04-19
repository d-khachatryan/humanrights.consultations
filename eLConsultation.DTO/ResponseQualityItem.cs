using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ResponseQualityItem
    {
        public int ResponseQualityID { get; set; }

        [Display(Name = "------")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string ResponseQualityName { get; set; }
    }
}
