using System;
using System.ComponentModel.DataAnnotations;
namespace eLConsultation.Data
{
    public class TargetGroupItem
    {
        [ScaffoldColumn(false)]
        public int TargetGroupID { get; set; }

        [Display(Name = "Թիրախային խումբ")]
        [StringLength(250, ErrorMessage = "Դաշտը չի կարող պարունակել ավելի քան 250 սիմվոլ")]
        public string TargetGroupName { get; set; }
    }
}
