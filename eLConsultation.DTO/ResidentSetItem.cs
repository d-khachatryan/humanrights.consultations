using System;
using System.ComponentModel.DataAnnotations;

namespace eLConsultation.Data
{
    public class ResidentSetItem
    {
        public int ResidentID { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Display(Name = "Ա․Հ․Փ․")]
        public string IdentificatorNumber { get; set; }

        [Display(Name = "Ծննդյան ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Սեռ")]
        public int? GenderID { get; set; }

        [Display(Name = "Սեռ")]
        public string GenderName { get; set; }

        [Display(Name = "Մարզ")]
        public int? RegionID { get; set; }

        [Display(Name = "Մարզ")]
        public string RegionName { get; set; }

        [Display(Name = "Բնակավայր")]
        public int? CommunityID { get; set; }

        [Display(Name = "Բնակավայր")]
        public string CommunityName { get; set; }

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

        [Display(Name = "Քաղաքացի")]
        public string ResidentName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }

        [Display(Name = "Բնակավայր")]
        public string ResidentRegistrationLocation
        {
            get
            {
                return RegionName + " " + CommunityName + " " + Street + " " + Building + " " + Home;
            }
        }
    }
}
