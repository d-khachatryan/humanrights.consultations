using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class AgeGroupItem
    {
        [ScaffoldColumn(false)]
        public int AgeGroupID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Տարիքային խումբ")]
        public string AgeGroupName { get; set; }
    }
}
