using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ResidentItem
    {
        [Required]
        public int ResidentID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Անունը պարտադիր է")]
        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ազգանունը պարտադիր է")]
        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Նույնականացման համարը պարտադիր է")]
        [Display(Name = "Անձը հաստատող փաստաթուղթ")]
        public string IdentificatorNumber { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Ծննդյան ամսաթիվը պարտադիր է")]
        [Display(Name = "Ծննդյան ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Սեռ")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Սեռը պարտադիր է")]
        public int? GenderID { get; set; }

        [Display(Name = "Մարզ")]
        public int? RegionID { get; set; }

        [Display(Name = "Բնակավայր")]
        public int? CommunityID { get; set; }

        [Display(Name = "Փողոց")]
        public string Street { get; set; }

        [Display(Name = "Տուն")]
        public string Building { get; set; }

        [Display(Name = "Բնակարան")]
        public string Home { get; set; }

        [Display(Name = "Ծննդյան տարեթիվ")]
        public Int16? BirthYear { get; set; }

        [Display(Name = "Հեռախոս")]
        public string Phone { get; set; }

        [Display(Name = "Էլ․ փոստ")]
        public string Email { get; set; }

        public string OperationType { get; set; }

        public InitializationTypes InitializationType { get; set; }
    }
}
