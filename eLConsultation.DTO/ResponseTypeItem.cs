using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ResponseTypeItem
    {
        public int ResponseTypeID { get; set; }

        [Display(Name = "------")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string ResponseTypeName { get; set; }
    }
}
