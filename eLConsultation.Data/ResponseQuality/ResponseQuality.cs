using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ResponseQuality
    {
        public int ResponseQualityID { get; set; }

        [Required]
        public string ResponseQualityName { get; set; }
    }
}
