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

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 50 սիմվոլ")]
        [Display(Name = "Տարիքային խումբ")]
        public string AgeGroupName { get; set; }
    }
}
