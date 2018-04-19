using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ResponseContentItem
    {
        public int ResponseContentID { get; set; }

        [Display(Name = "------")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        public string ResponseContentName { get; set; }
    }
}
