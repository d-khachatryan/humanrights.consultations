using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ResponseTypeItem
    {
        public int ResponseTypeID { get; set; }

        [Display(Name = "------")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        public string ResponseTypeName { get; set; }
    }
}
