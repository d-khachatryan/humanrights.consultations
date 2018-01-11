using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class TargetGroup
    {
        public int TargetGroupID { get; set; }

        public string TargetGroupName { get; set; }
    }
}
