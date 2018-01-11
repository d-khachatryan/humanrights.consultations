using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ResponseContent
    {
        public int ResponseContentID { get; set; }

        [Required]
        public string ResponseContentName { get; set; }
    }
}
