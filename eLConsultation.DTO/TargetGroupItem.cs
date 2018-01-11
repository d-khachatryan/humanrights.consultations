using System;
using System.ComponentModel.DataAnnotations;
namespace eLConsultation.Data
{
    public class TargetGroupItem
    {
        [ScaffoldColumn(false)]
        public int TargetGroupID { get; set; }

        [MaxLength(250)]
        [Display(Name = "Թիրախային խումբ")]
        public string TargetGroupName { get; set; }
    }
}
