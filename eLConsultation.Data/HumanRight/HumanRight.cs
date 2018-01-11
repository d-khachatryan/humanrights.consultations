using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class HumanRight
    {
        public int HumanRightID { get; set; }

        public string HumanRightName { get; set; }
    }
}
