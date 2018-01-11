using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class CommunityItem
    {
        [ScaffoldColumn(false)]
        public int CommunityID { get; set; }

        [Display(Name = "Մարզ")]
        [UIHint("Region")]
        public int RegionID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Բնակավայր")]
        public string CommunityName { get; set; }
    }
}
