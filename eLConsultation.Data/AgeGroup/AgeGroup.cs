using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class AgeGroup
    {
        public int AgeGroupID { get; set; }

        public string AgeGroupName { get; set; }
    }
}
