using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class Resident
    {
        public int ResidentID { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Display(Name = "Նույնականացման համար")]
        public string IdentificatorNumber { get; set; }

        [Display(Name = "Ծննդյան ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Սեռ")]
        [UIHint("Gender")]
        public int? GenderID { get; set; }

        [Display(Name = "Մարզ")]
        [UIHint("Region")]
        public int? RegionID { get; set; }

        [Display(Name = "Բնակավայր")]
        public int? CommunityID { get; set; }

        [Display(Name = "Փողոց")]
        public string Street { get; set; }

        [Display(Name = "Տուն")]
        public string Building { get; set; }

        [Display(Name = "Բնակարան")]
        public string Home { get; set; }

        [Display(Name = "Ծննդյան ամսաթիվ")]
        public string BirthYear { get; set; }

        [Display(Name = "Հեռախոս")]
        public string Phone { get; set; }

        [Display(Name = "Էլ․ փոստ")]
        public string Email { get; set; }
    }
}
